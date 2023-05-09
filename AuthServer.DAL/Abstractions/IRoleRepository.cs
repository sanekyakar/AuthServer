using AuthServer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.DAL.Abstractions
{
    public interface IRoleRepository
    {
        public void Add(Role role);
        public void Remove(Role role);
        public IEnumerable<Role> GetAll();
        public Role GetByRoleId(long id);

    }
}
