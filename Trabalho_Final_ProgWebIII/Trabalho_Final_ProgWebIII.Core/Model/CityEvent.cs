using System.ComponentModel.DataAnnotations;

namespace Trabalho_Final_ProgWebIII.Core.Model
{
    public class CityEvent
    {

        //[Required]
        //public long? IdEvent { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Data é obrigatória")]
        public DateTime DateHourEvent { get; set; }

        [Required(ErrorMessage = "Local é obrigatório")]
        public string Local { get; set; }

        public string? Address { get; set; }

        [Range(0, 999999.99)]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Status é obrigatório")]
        public bool? Status { get; set; }
    }
}
