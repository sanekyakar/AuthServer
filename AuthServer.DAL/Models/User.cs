using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.DAL.Models
{
    public class User
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
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
        public Role Role { get; set; } = new();

        public User()
        {

        }
        public User(string login , string password):this(login,password,null)
        {

        }
        public User(string login , string password , Role role)
        {
            Login= login;
            Password= password;
            Role= role;
        }
    }
}
