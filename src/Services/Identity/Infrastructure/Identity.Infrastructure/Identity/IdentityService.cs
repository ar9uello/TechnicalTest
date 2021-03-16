using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using TechnicalTest.Identity.Application.Contracts.Identity;

namespace TechnicalTest.Identity.Infrastructure
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
    }
}
