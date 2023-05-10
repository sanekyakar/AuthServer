using AuthServer.Bll.Abstractions;
using AuthServer.DAL.Abstractions;
using AuthServer.Models;
using Microsoft.AspNetCore.Mvc;
using Mapping;
using AuthServer.Bll.Models;
using Jose;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace AuthServer.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        //private readonly IUserRepository _userRepository;
        //private readonly TokenOptions _options;

        public AccountController(IAccountService accountService, IUserRepository userRepository
            /*IOptions<TokenOptions> tokenOptins*/)
        {
            _accountService = accountService;
            //_userRepository = userRepository;
            //_options = (TokenOptions?)tokenOptins;
        }

        [HttpPost("Registration")]
        public IActionResult Register([FromBody] Models.AccountInfo accountInfo )
        {
            var mappingAccountInfo = Mapper.Map<Models.AccountInfo, Bll.Models.AccountInfo>(accountInfo);
            try
            {
                _accountService.Register(mappingAccountInfo);
                return Ok(new ResulMessage("Регистрация прошла успешно", 200));
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Authentication")]
        public IActionResult Authentication([FromBody] Models.AccountInfo accountInfo)
        {
            var mappingAccountInfo = Mapper.Map<Models.AccountInfo, Bll.Models.AccountInfo>(accountInfo);
            try
            {
                var result=_accountService.Authentication(mappingAccountInfo);

                return Json(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new ResulMessage(ex.Message,400));
            }
        }
        [Authorize(Roles ="Admin")]
        [HttpGet("TestAuthRole")]
        public IActionResult TestAuth()
        {
            return Ok(new
            {
                Message = "Админ достучался"
            }); 
        }
    }
}
