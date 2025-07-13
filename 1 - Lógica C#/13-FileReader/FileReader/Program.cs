using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Arquivo q quero abrir
            string arq = args[0];
            string line;

            try
            {
                StreamReader sr = new StreamReader(arq);

                line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
