using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula7_LetsCode
{
    internal class Circulo : Forma
    {
        public double Raio { get; set; }
        public override string CalcularArea()
        {
            return $"A área do círculo de raio {Raio} é {Math.Pow(Raio, 2) * Math.PI:f2}";
        }
    }
}
