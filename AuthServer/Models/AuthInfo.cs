namespace AuthServer.Models
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
    }
}
