using System.ComponentModel.DataAnnotations;

namespace WebAPI_2608
{
    public class Cliente
    {
        [MinLength(11)]
        [MaxLength(11)]
        [Required]
        public string CPF { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public DateTime DataDeNascimento { get; set; }
        
        [Range(0,100)]
        public int Idade { get; set; }

        //public DateTime Date { get; set; }

        //public int TemperatureC { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        //public string? Summary { get; set; }
    }
}