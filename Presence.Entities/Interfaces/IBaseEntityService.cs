using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Presence.Entities.Models;

namespace Presence.Entities.Interfaces
{
    public interface IBaseEntityService<TEntity> where TEntity : BaseIdCodeEntity
    {
        TEntity GetById(int id);
        TEntity GetByCode(string code);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filterPredicate);
        IQueryable<TEntity> Get<TKey>(Expression<Func<TEntity, bool>> filterPredicate, Expression<Func<TEntity, TKey>> orderPredicate);        
    }
}
