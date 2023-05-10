
using AuthServer.Bll.Models;

namespace AuthServer.Bll.Abstractions
{
    public interface IAccountService
    {
        public void Register(AccountInfo accountInfo);

        public AuthInfo Authentication(AccountInfo accountInfo);

        
    }
}
