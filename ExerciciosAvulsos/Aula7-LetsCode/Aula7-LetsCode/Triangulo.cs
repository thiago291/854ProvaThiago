using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula7_LetsCode
{
    internal class Triangulo : Forma
    {
        public decimal Altura { get; set; }
        public decimal Base { get; set; }
        public override string CalcularArea()
        {
            return $"A área do triângulo de base {Base} e altura {Altura} é {(Base * Altura) / 2}";
        }
    }
}
