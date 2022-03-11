using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backEnd.Models
{
    [Table("Login")]
    public class Login
    {
        [Key]
        [Column("id")]
        public int Id { get; set; } 

        [Display(Name = "Usuário")]
        [Column("username")]
        public string Username { get; set; }

        [Display(Name = "Senha")]
        [Column("password")]
        public string Password { get; set; }
    }
}
