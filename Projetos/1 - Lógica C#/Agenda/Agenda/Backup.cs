using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class Backup
    {
        public static String filename = "";

        public static void salvar(ref String[] nomes, ref String[] emails, int TL)
        {
            StreamWriter sw = new StreamWriter(filename);

            for (int i = 0; i < TL; i++)
                sw.WriteLine(nomes[i]+"-"+emails[i]);

            sw.Close();
        }

        public static void restaurar(ref String[] nomes, ref String[] emails, ref int TL)
        {
            TL = 0;
            StreamReader sr = new StreamReader(filename);

            String line = sr.ReadLine();
            while (line != null && TL < nomes.Length)
            {
                string[] partes = line.Split('-');
                if (partes.Length == 2)
                {
                    nomes[TL] = partes[0];
                    emails[TL] = partes[1];
                    TL++;
                }

                line = sr.ReadLine();
            }

            sr.Close();
        }
    }
}