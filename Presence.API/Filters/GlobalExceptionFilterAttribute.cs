using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;
using Presence.Entities.Interfaces;

namespace Presence.API.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute, IAutofacExceptionFilter
    {
        private readonly IUserManagementService _userManagementService;

        public GlobalExceptionFilter(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            var user = _userManagementService.LoggedUser;
            var msg = String.Format("{0}: {1} {2} - {3}", user!= null ? user.Username : "UNKNOWN_USER", 
                context.Request.Method, context.Request.RequestUri, context.Exception.Message);
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(msg),
            });
        }
    }
}