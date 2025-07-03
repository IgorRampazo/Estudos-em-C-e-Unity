using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeticaoWhile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;

            Console.WriteLine("Informe o numero a ser verificado: ");
            n = int.Parse(Console.ReadLine());

            if (primo(n))
                Console.WriteLine("Numero primo");
            else
                Console.WriteLine("Numero n primo");
        }

        static bool primo(int n)
        {
            int i = n - 1;

            if (n < 2)
                return false;

            else if (n >= 2 && n < 4)
                return true;

            while (i > 1)
            {
                if (n % i == 0)
                    return false;

                i--;
            }

            return true;
        }
    }
}
