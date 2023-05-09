using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.DAL.Models
{
    public class Role
    {
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// Название роли
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }
        
        public long UserId { get; set; }
    }

}
