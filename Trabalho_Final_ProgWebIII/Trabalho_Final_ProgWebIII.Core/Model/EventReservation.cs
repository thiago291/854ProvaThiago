using System.ComponentModel.DataAnnotations;

namespace Trabalho_Final_ProgWebIII.Core.Model
{
    public class EventReservation
    {   
        //public long? IdReservation { get; set; }

        [Required(ErrorMessage = "ID do evento é obrigatória")]
        public long IdEvent { get; set; }

        [Required(ErrorMessage = "Nome do titular da reserva é obrigatório")]
        public string PersonName { get; set; }

        [Range(0,100000)]
        [Required(ErrorMessage = "Quantidade de ingressos é obrigatória")]
        public long Quantity { get; set; }
    }
}
