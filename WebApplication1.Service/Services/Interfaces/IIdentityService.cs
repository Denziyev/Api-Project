using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Service.Dtos.Accounts;
using WebApplication1.Service.Responses;

namespace WebApplication1.Service.Services.Interfaces
{
    public interface IIdentityService
    {
        public Task<ApiResponse> Register(RegisterDto dto);
        public Task<ApiResponse> Login(LoginDto dto);
    }
}
