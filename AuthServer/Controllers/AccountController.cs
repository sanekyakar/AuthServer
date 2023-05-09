using AuthServer.Bll.Abstractions;
using AuthServer.DAL.Abstractions;
using AuthServer.Models;
using Microsoft.AspNetCore.Mvc;
using Mapping;
using AuthServer.Bll.Models;

namespace AuthServer.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserRepository _userRepository;

        public AccountController(IAccountService accountService, IUserRepository userRepository)
        {
            _accountService = accountService;
            _userRepository = userRepository;

        }

        [HttpPost("Registration")]
        public IActionResult Register([FromBody] Models.AccountInfo accountInfo )
        {
            var mapp = Mapper.Map<Models.AccountInfo, Bll.Models.AccountInfo>(accountInfo);
            try
            {
                _accountService.Register(mapp);
                return Ok(new ResulMessage("Регистрация прошла успешно", 200));
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
