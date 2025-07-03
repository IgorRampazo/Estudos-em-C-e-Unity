using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variaveis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // # # # # --- Variáveis --- # # # # //

            int vINT = 5;
            float vFLOAT = 5.0f;
            double vDOUBLE = 5.2;
            bool vTRUE = true;
            string vString = "Texto";

            Console.WriteLine($"{vINT} > {vDOUBLE}: {vINT > vDOUBLE}");
            Console.WriteLine($"{vINT} != {vDOUBLE}: {vINT != vDOUBLE}");
            Console.WriteLine($"{vINT} < {vDOUBLE}: {vINT < vDOUBLE}");
            Console.WriteLine($"{vINT} == {vDOUBLE}: {vINT == vDOUBLE}");
        }
    }
}
