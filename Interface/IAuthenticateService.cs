using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.Model;

namespace Webapi.Interface
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(LoginRequestDTO request, out string Token);
    }
}
