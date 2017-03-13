using System;
using System.Security.Claims;

namespace $safeprojectname$.Models
{
    public class LoggedUser : ClaimsPrincipal
    {
        public LoggedUser(ClaimsPrincipal principal)
            : base(principal)
        {
        }

        public string Name => FindFirst(ClaimTypes.Name).Value;
        public string Email => FindFirst(ClaimTypes.Email).Value;
        public string LoginId => FindFirst(ClaimTypes.NameIdentifier).Value;
        public int UserId => Convert.ToInt32(FindFirst(ClaimTypes.PrimarySid).Value);
    }
}