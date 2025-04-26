using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        public AuthController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(Models.DTO.LoginRequest loginRequest)
        {
            //Validate the incoming request

            // Check id user is authenciated
            var isAuthenciated  = await userRepository.AutenticateAsync(loginRequest.UserName, loginRequest.Password);
            if (isAuthenciated)
            {
                // Generate a JWT Token
            }
            return BadRequest("Incorrect Credentials");
            // Check username and password
        }
    }
}
