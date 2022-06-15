using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Classes
{
    public class DadosCadastro
    {
        public Guid Codigo { get; private set; } = Guid.NewGuid();
        public DateTime DataCadastrado { get; private set; } = DateTime.Now;
    }
}
