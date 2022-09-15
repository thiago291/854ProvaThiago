using System.ComponentModel.DataAnnotations;

namespace Trabalho_Final_ProgWebIII.Core.Model
{
    public class CityEvent
    {

        [Required]
        public long? IdEvent { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public DateTime DateHourEvent { get; set; }

        [Required]
        public string? Local { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal? Price { get; set; }

        //[Required]

        //public bool? Status { get; set; }
        //[Required]
        //public bit? Status { get; set; }
    }
}
