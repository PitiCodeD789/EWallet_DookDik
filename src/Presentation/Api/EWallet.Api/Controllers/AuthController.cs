using EWallet.Core.Models.MobileAndApi.Auth;
using EWallet.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult CheckEmail([FromBody] CheckEmailModel req)
        {
            var email = req.Email;

            bool isExistEmail = _authService.ExistingEmail(email);

            var res = new { isExistEmail };

            return Ok(res);
        }
    }
}