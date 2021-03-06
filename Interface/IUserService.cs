using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.Model;
namespace Webapi.Interface
{
    public interface IUserService
    {
        bool Isvalid(LoginRequestDTO login);
    }

    public class UserService : IUserService
    {
        public bool Isvalid(LoginRequestDTO login)
        {
            return true;
        }
    }
}
