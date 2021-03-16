using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using TechnicalTest.Movie.Application.Contracts.Identity;

namespace TechnicalTest.Movie.Infrastructure
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string GetUserEmail()
        {
            return _context.HttpContext?.User?.FindFirst(ClaimTypes.Email).Value;
        }

        public bool IsUserAdmin()
        {
            return IsUserInRole(Role.Administrator);
        }

        public bool IsUserRole()
        {
            return IsUserInRole(Role.User);
        }

        public bool IsUserInRole(Role role)
        {
            var claimList = _context.HttpContext?.User?.FindAll(ClaimTypes.Role);
            if (claimList == null) return false;
            return claimList.Any(x => x.Value == Enum.GetName(typeof(Role), role));
        }

    }
}
