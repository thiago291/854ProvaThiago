using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    internal class Vacina
    {
        Guid idUnicoVacina = Guid.NewGuid();
        Guid idTipoVacina = Guid.NewGuid();
        string Nome;
        string Lote;
        DateTime DataAplicacao;
        int MesesDuracao;
    }
}
