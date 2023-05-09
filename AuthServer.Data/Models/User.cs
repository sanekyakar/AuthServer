using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Data.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Роль
        /// </summary>
        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}
