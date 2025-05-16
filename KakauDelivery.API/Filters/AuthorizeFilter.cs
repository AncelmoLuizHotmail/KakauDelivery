using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KakauDelivery.API.Filters
{
    public class AuthorizeFilter : IAsyncAuthorizationFilter
    {
        private readonly string[] _allowedRoles;

        public AuthorizeFilter(params string[] allowedRoles)
        {
            _allowedRoles = allowedRoles;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata
             .OfType<AllowAnonymousAttribute>().Any();

            if (allowAnonymous)
                return;

            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (_allowedRoles.Any() && !_allowedRoles.Any(role => user.IsInRole(role)))
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
