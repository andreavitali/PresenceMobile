using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Presence.EFDataServices.Models
{
    public class DBUtility
    {
        #region Transform lamba parameter

        public static Expression<Func<TNewTarget, bool>> TransformPredicateLambda<TOldTarget, TNewTarget>(Expression<Func<TOldTarget, bool>> predicate)
        {
            var lambda = (LambdaExpression)predicate;
            if (lambda == null) throw new NotSupportedException();

            var oldParameter = predicate.Parameters[0];
            var newParameter = Expression.Parameter(typeof(TNewTarget), oldParameter.Name);

            var result = new ParamTransformExpressionVisitor<TNewTarget>(newParameter).Visit(lambda.Body);
            return Expression.Lambda<Func<TNewTarget, bool>>(result, newParameter);
        }

        private class ParamTransformExpressionVisitor<T> : ExpressionVisitor
        {
            ParameterExpression _parameter;

            public ParamTransformExpressionVisitor(ParameterExpression parameter)
            {
                _parameter = parameter;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return _parameter;
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                if (node.Member.MemberType == System.Reflection.MemberTypes.Property)
                {
                    MemberExpression memberExpression = null;
                    var memberName = node.Member.Name;
                    var otherMember = typeof(T).GetProperty(memberName);
                    memberExpression = Expression.Property(Visit(node.Expression), otherMember);
                    return memberExpression;
                }
                else
                {
                    return base.VisitMember(node);
                }
            }
        }

        #endregion
    }
}
