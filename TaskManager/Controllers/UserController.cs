using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TaskManager.Controllers
{
    public class UserController : Controller
    {
        private IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            return View();
        }
    }
}
