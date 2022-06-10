using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Enums;

namespace PetShop
{
    internal class TipoVacina
    {
        private Guid IDUnicoVacina { get; } = Guid.NewGuid();
        public string nome;
        public int mesesDuracao;
        public List<Especie> especies;

        public Guid ObterIdUnicoVacina()
        {
            return IDUnicoVacina;
        }
    }
}
