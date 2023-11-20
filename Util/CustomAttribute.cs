using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace DemoCustomAuth.Util
{
    public class MyAuthAttribute : Attribute, IAuthorizationFilter
    {
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
                //return "ChallengeResult" to redirect to login page (for example)
                context.Result = new ChallengeResult(CookieAuthenticationDefaults.AccessDeniedPath);
            }
        }

        private bool CheckPermissions(AuthorizationFilterContext context)
        {
            if(context.HttpContext.User.Identity.IsAuthenticated)
            {
                //check if user is in role
                if(context.HttpContext.User.IsInRole("Admin"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

