using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;

namespace DemoCustomAuth.Util
{
    public class MyAuthAttribute : Attribute, IAuthorizationFilter
    {
        public string? Role { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //check access 
            if (CheckPermissions(context))
            {
                //all good, add optional code if you want. Or don't
            }
            else
            {
                //DENIED!
                //return access denied on the razor page
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "Identity", page = "/Account/AccessDenied" }));
            }
        }

        private bool CheckPermissions(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User?.Identity?.IsAuthenticated == true)
            {
                //check if user is in role
                if (!string.IsNullOrEmpty(Role) && context.HttpContext.User.IsInRole(Role))
                {
                    return true;
                }
                //if the user is not in the role, we check if the role is empty
                //if the role is empty, we allow access
                else if (!string.IsNullOrEmpty(Role) && !context.HttpContext.User.IsInRole(Role))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}

