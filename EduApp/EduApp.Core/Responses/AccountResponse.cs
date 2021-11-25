using EduApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace EduApp.Core.Responses
{
    public class AccountResponse
    {
        public IEnumerable<Claim> Claims { get; set; }
        public Guid AccountId { get; set; }

        public AccountResponse(Account account)
        {
            AccountId = account.Id;
            Claims = account.GetClaims();
        }
    }
}
