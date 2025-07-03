using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Operadores
{
    internal class Program
    {
        // # # # # --- Operadores/Repetição/Concatenção --- # # # # //

        // ++/-- : Incremento/Decremento.
        // +,-,*,/,% : Soma, Subtração, Multiplicação, Divisão e Resto.
        // >,<,>=,<=,==,!= : Maior, Menor, Maior/Igual, Menor/Igual, Igual e Diferente.
        // &&,||, `: E, OU, NOT
        // =,+=,-=,*=,/=, %= : Atribuições
        // ?:,??,??= : Ternário, Coalescência, Atribuição coalescente 

        static void Main(string[] args)
        {
            int tab1 = 2, tab2 = 4;
            int i, j = 0;

            Console.WriteLine($"Tabuada do {tab1}\n");
            for (i = 0; i < 10;  i++)
                Console.WriteLine($"{tab1} x {i+1} = {mx(tab1, i+1)}");

            Console.WriteLine("\nTabuada do " + tab2 + "\n");
            while (j < 10)
                Console.WriteLine(tab2 + " x " + ++j + " = " + mx(tab2, j));
        }

        static int mx(int a, int b)
        {
            return a * b;
        }
    }
}