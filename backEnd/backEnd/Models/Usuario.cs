using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backEnd.Models
{
    [Table("Usuario")]
    public class Usuario
    {

        [Key]
        [Display(Name = "Id")]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("name")]
        public string Name { get; set; }

        [Display(Name = "CPF")]
        [Column("cpf")]
        public string Cpf { get; set; }

        [Display(Name = "Telefone")]
        [Column("phone")]
        public string? Phone { get; set; }
        
        [Display(Name = "Endereço")]
        [Column("address")]
        public string? Address { get; set; }
    }
}
