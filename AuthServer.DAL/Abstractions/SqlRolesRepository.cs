using AuthServer.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.DAL.Abstractions
{
    public class SqlRolesRepository : IRoleRepository
    {
        private readonly AuthContext _authContext;
        public SqlRolesRepository(AuthContext authContext)
        {
            _authContext = authContext;
        }
        public void Add(Role entity)
        {
            _authContext.Roles.Add(entity);
            _authContext.SaveChanges();
        }

        public Role Get(long id)
        {
            return _authContext.Roles
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

        }

        public void Remove(Role entity)
        {
            _authContext.Remove(entity);
            _authContext.SaveChanges();
        }

        public void Update(Role entity)
        {
            _authContext.Roles.Update(entity);
            _authContext.SaveChanges();
        }

        public IEnumerable<Role> GetAll()
        {
            return _authContext.Roles
                .AsNoTracking()
                .ToList();
        }

        public Role GetByRoleId(long id)
        {
            return _authContext.Roles
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
