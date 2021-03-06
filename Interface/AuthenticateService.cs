using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Webapi.Model;

namespace Webapi.Interface
{
    public class AuthenticateService:IAuthenticateService
    {
        private readonly IUserService userService;
        private readonly TokenManagement tokenmanage;

        public AuthenticateService(IUserService userService,IOptions<TokenManagement> tokenmanage)
        {
            this.userService = userService;
            this.tokenmanage = tokenmanage.Value;
        }
        public bool IsAuthenticated(LoginRequestDTO request, out string token)
        {
            token = String.Empty;
            if (!userService.Isvalid(request))
            {
                return false;

            }
            IEnumerable<Claim> clams = new Claim[] { new Claim(ClaimTypes.Name,request.Username) };
            var key = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(tokenmanage.Secret));
            var credials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwttoken = new JwtSecurityToken(
                tokenmanage.Issuer, tokenmanage.Audience, clams,expires: DateTime.Now.AddMinutes(tokenmanage.AccessExpiration), signingCredentials: credials);
            token = new JwtSecurityTokenHandler().WriteToken(jwttoken);
            return true;

        }

    }
}