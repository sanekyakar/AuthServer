using System.ComponentModel.DataAnnotations;

namespace AuthServer.Models
{
    public class AccountInfo
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
