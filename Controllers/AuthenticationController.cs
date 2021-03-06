using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.Interface;
using Webapi.Model;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService authenticateService;

        public AuthenticationController(IAuthenticateService authenticateService )
        {
            this.authenticateService = authenticateService;
        }

        [AllowAnonymous]
        [HttpPost,Route("RequestToken")]
        public IActionResult RequestToken([FromBody] LoginRequestDTO dTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }
            return Ok();
        }
    }
}
