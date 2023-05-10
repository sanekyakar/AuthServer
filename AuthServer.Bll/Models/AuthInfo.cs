using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Bll.Models
{
    /// <summary>
    /// Класс для результата авторизации
    /// </summary>
    public class AuthInfo
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Значение токена
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Роль в системе
        /// </summary>
        public string Role { get; set; }

        public AuthInfo()
        {

        }
        public AuthInfo(string login , string token , string role)
        {
            Login= login;
            Token= token;
            Role= role;
        }
    }
}
