using EduApp.Core.Repositories;
using EduApp.Core.Requests;
using EduApp.Core.Responses.Auth;
using EduApp.Core.Services;
using System.Threading.Tasks;

namespace EduApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _uow;

        public AccountService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<AccountResponse> GetAccountPermissionsOrDefault(LoginRequest request)
        {
            var account = await Task.Run(() => _uow.AccountRepository.FindByUsername(request.Username));

            if (account?.VerifyPassword(request.Password) is true)
            {
                var response = new AccountResponse(account);

                return response;
            }

            return null;
        }
    }
}
