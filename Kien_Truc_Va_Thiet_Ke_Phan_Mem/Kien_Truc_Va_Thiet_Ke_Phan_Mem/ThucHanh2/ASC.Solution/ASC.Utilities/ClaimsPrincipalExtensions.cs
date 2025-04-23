using System;
using System.Linq;
using System.Security.Claims;

namespace ASC.Utilities
{
    public static class ClaimsPrincipalExtensions
    {
        public static CurrentUser GetCurrentUserDetails(this ClaimsPrincipal principal)
        {
            if (principal == null || !principal.Claims.Any())
                return null;

            var name = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var roles = principal.Claims
                                 .Where(c => c.Type == ClaimTypes.Role)
                                 .Select(c => c.Value)
                                 .ToArray();
            var isActiveClaim = principal.Claims
                                         .FirstOrDefault(c => c.Type == "IsActive")?.Value;

            bool isActive = false;
            if (!string.IsNullOrEmpty(isActiveClaim))
            {
                Boolean.TryParse(isActiveClaim, out isActive);
            }

            return new CurrentUser
            {
                Name = name,
                Email = email,
                Roles = roles,
                IsActive = isActive
            };
        }
    }
}
