using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Enums
{
    public class Vacinas
    {
        private Guid IdVacina = Guid.NewGuid();
        Guid IdAnimal = Guid.NewGuid();
        TipoVacina TipoVacina;
        DateTime DataAplicacao;
        string Lote;
        DateTime DataRegistro;
    }
}
