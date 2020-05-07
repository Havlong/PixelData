using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PixelDataApp.Transfer;
using PixelDataApp.Models;
using static BCrypt.Net.BCrypt;


namespace PixelDataApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void signUp(UserDTO user)
        {
            User userModel = new User();
            userModel.HashPassword = HashPassword(user.Password);
        }

        public void login(string username, string password)
        {
            User DBUser = new User();
            if (Verify(password, DBUser.HashPassword))
            {

            }
        }
    }
}