

using AuthServer.DAL.Models;

namespace AuthServer.DAL.Abstractions
{
    public interface IUserRepository 
    {
        void Add(User entity);

        void Update(User entity);

        void Remove(User entity);
        User Get(long id);

        User FindByLogin(string login);

        IEnumerable<User> FindAll();
    }
}
