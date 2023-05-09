using AuthServer.Bll.Abstractions;
using AuthServer.Bll.Models;
using AuthServer.DAL.Abstractions;
using AuthServer.DAL.Models;
using Mapping;

namespace AuthServer.Bll.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Authentication(AccountInfo accountInfo)
        {
            throw new NotImplementedException();
        }

        public void Register(AccountInfo accountInfo)
        {
            try
            {
                var user = _userRepository
                    .FindByLogin(accountInfo.Login);
                    

                if (user != null)
                    throw new Exception("Пользователь с таким логином уже существует, пожалуйста, выберите другой логин");

                var userDb = CreateUser(accountInfo);

                _userRepository.Add(userDb);
            }

            catch (Exception ex)
            {
                throw new Exception("Произошла непредвинденная ошибка в базе данных");
            }
        }

        private DAL.Models.User CreateUser(AccountInfo accountInfo)
        {
            var userDb = new DAL.Models.User(accountInfo.Login, accountInfo.Password, new DAL.Models.Role { Id = 2 });
            return userDb;
        }

    }
}
