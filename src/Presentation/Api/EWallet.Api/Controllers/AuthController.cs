using EWallet.Core.Models.MobileAndApi.Auth;
using EWallet.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

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

            string refNumber = GetRefOtp();
            string otpNumber = GetOtp();

            bool canSaveOtp = _authService.SaveOtp(email, refNumber, otpNumber);
            if (!canSaveOtp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Can not save OTP" });
            }

            Task.Run(() => SendOtp(email, refNumber, otpNumber));

            var res = new CheckEmailResult()
            {
                IsExistEmail = isExistEmail,
                RefNumber = refNumber
            };

            return Ok(res);
        }

        private void SendOtp(string email, string refNumber, string otpNumber)
        {
            try
            {
                var username = "student@enixer.net";
                var password = "Gg123456789";

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtpm.csloxinfo.com");

                mail.From = new MailAddress("student@enixer.net");
                mail.To.Add(email);
                mail.Subject = "Otp number";
                mail.Body = $"ref: {refNumber}, otp: {otpNumber}";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Send Email error => ", ex.Message);
            }
        }

        private string GetRefOtp()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string GetOtp()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}