using EduApp.Core.Requests;
using EduApp.Core.Responses;
using System.Threading.Tasks;

namespace EduApp.Core.Services
{
    public interface IAccountService
    {
        public Task<AccountResponse> GetAccountPermissionsOrDefault(LoginRequest request);
    }
}
