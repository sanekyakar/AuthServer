using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Bll.Models
{
    public class Role
    {
        public long Id { get; set; }
        /// <summary>
        /// Название роли
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }

        //public long? UserId { get; set; }

        public void SetRoleName(long id)
        {
            Name = id switch
            {
                1 => "Admin",
                2 => "User",
                _ => "Observer",
            };
        }
    }
}
