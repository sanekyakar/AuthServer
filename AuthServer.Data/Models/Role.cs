using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Data.Models
{
    /// <summary>
    /// Роль
    /// </summary>
    public class Role
    {
        public long Id { get; set; }
        /// <summary>
        /// Название роли
        /// </summary>
        public string Name { get; set; }

        public long UserId { get; set; }   
     
    }
}
