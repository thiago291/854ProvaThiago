using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraIR.Presentation
{
    public class Screen : IScreen
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
