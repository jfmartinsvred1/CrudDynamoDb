using CrudDynamoDB.Models;
using CrudDynamoDB.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrudDynamoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger,IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromHeader]string site)
        {
            var users = await _userRepository.GetUsers(site);
            return Ok(users);
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            string site = Request.Headers["site"];
            var users = await _userRepository.FindByEmail(site,email);
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _userRepository.Add(user);
            return Ok("Created");
        }
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _userRepository.Update(user);
            return Ok("Update");
        }
        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email)
        {
            string site = Request.Headers["site"];
            await _userRepository.Delete(site,email);
            return Ok("Deleted");
        }
    }
}
