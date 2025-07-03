using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeticaoFor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float sum = 0;
            int i, n;

            Console.Write("Informe o número de valores a ser passado: ");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine("\n");

            for (i = 0; i < n; i++)
            {
                Console.Write($"Informe o {i + 1}° número: ");
                sum += float.Parse(Console.ReadLine());
            }

            Console.WriteLine($"\nMédia Final dos {n} números: {sum/n}");
        }
    }
}
