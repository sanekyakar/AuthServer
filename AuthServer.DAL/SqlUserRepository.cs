using AuthServer.DAL.Abstractions;
using AuthServer.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.DAL
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly AuthContext _authContext;

        public SqlUserRepository(AuthContext authContext)
        {
            _authContext = authContext;
        }

        public void Add(User entity)
        {
            _authContext.Users.Add(entity);
            _authContext.SaveChanges();
        }

        public User Get(long id)
        {
            return _authContext.Users
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

        }

        public User FindByLogin(string login)
        {
            return _authContext.Users
                .AsNoTracking()
                .FirstOrDefault(u=>u.Login==login);
        }

        public void Remove(User entity)
        {
            _authContext.Users.Remove(entity);
            _authContext.SaveChanges();
        }

        public void Update(User entity)
        {
            _authContext.Users.Update(entity);
            _authContext.SaveChanges();
        }

        public IEnumerable<User> FindAll()
        {
            return _authContext.Users
                .AsNoTracking()
                .ToList();
        }
    }
}
