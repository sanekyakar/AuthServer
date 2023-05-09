namespace AuthServer.Bll.Models
{
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
        public Role Role { get; set; }
        //public long RoleId { get; set; }
    }
}
