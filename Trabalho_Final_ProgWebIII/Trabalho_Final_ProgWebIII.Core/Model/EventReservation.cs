using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final_ProgWebIII.Core.Model
{
    public class EventReservation
    {
        [Required]
        public long? IdReservation { get; set; }

        [Required]
        public long? IdEvent { get; set; }

        [Required]
        public string? PersonName { get; set; }

        [Required]
        public string? Quantity { get; set; }
    }
}
