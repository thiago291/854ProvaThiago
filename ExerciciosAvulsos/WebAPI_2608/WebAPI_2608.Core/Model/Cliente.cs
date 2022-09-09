using System.ComponentModel.DataAnnotations;

namespace WebAPI_2608.Core.Model
{
    public class Cliente
    {
        [MinLength(11)]
        [MaxLength(11)]
        [Required]
        public string? CPF { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
        
        [Range(0,100)]
        public int Idade { get; set; }
    }
}