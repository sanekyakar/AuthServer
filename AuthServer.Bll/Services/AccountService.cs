using AuthServer.Bll.Abstractions;
using AuthServer.Bll.Models;
using AuthServer.DAL.Abstractions;
using AuthServer.DAL.Models;
using Jose;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthServer.Bll.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOptions<TokenOptions> _tokenOptions;

        public AccountService(IUserRepository userRepository, IOptions<TokenOptions> optAccess)
        {
            _userRepository = userRepository;
            _tokenOptions = optAccess;
        }

        public AuthInfo Authentication(AccountInfo accountInfo)
        {
            var user = _userRepository
                .FindByLogin(accountInfo.Login);

            if (user == null)
                throw new Exception("пользователь не найден");

            var authInfo = CreateAuthenticationScheme(user);

            return authInfo;
        }

        public void Register(AccountInfo accountInfo)
        {

            var user = _userRepository
                .FindByLogin(accountInfo.Login);

            //if (user?.Role == null)
            //    throw new Exception("Ошибка связаная с ролью пользователя");

            if (user != null)
                throw new Exception("Пользователь с таким логином уже существует, пожалуйста, выберите другой логин");

            var userDb = CreateUser(accountInfo);

            _userRepository.Add(userDb);

        }

        private DAL.Models.User CreateUser(AccountInfo accountInfo)
        {
            var userDb = new DAL.Models.User(accountInfo.Login, accountInfo.Password, new DAL.Models.Role { Id = 2 });
            return userDb;
        }

        //Тут грязновато, можно отрефакторить
        private AuthInfo CreateAuthenticationScheme(DAL.Models.User user)
        {
            List<Claim> claims = new List<Claim>
            {
                SetRoleClaim(user.Role.Name),
                SetLoginClaim(user.Login)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.Value.SecretKey));

            var jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Value.Issuer,
                audience: _tokenOptions.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));

            var readyJwtToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            var authInfo = InitialAuthInfo(claims);
            authInfo.Token = readyJwtToken;

            return authInfo;
        }

        private Claim SetRoleClaim(string role)
        {
            switch (role)
            {
                case "Admin":
                    return new Claim(ClaimTypes.Role, "Admin");
                case "User":
                    return new Claim(ClaimTypes.Role, "User");
                default:
                    return new Claim(ClaimTypes.Role, "User");
            }
        }

        private Claim SetLoginClaim(string login) =>
            new Claim(ClaimTypes.Name, login);

        //Можно дернуть логин из модели пользователя, но я пока решил дернуть из Claim
        private AuthInfo InitialAuthInfo(IEnumerable<Claim> claims)
        {
            var role = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            var login = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;

            var authInfo = new AuthInfo
            {
                Role = role,
                Login = login
            };
            return authInfo;
        }

    }
}
