using EduApp.Core.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace EduApp.Core.Responses
{
    public class AccountResponse
    {
        public IEnumerable<Claim> Claims { get; set; }

        public AccountResponse(Account account)
        {
            Claims = account.GetClaims();
        }
    }
}
