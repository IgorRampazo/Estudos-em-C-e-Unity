using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class Program
    {
        // # # # --- Constantes --- # # # //
        static int MR = 200;

        static int buscar_contato(String[] emails, String email, int TL)
        {
            int i = 0;
            while (i < TL)
            {
                if (email.Equals(emails[i]))
                    return i;
                i++;
            }

            return -1;
        }

        static void inserir_contato(ref String[] nomes, ref String[] emails, ref int TL)
        {
            if (TL == Program.MR)
                Console.WriteLine("* * * Número de Contatos atingiu o Limite * * *");

            else
            {
                ConsoleKey option;

                do
                {
                    Console.Clear();
                    Console.WriteLine("# # # ---- Inserir Contato ---- # # #\n");

                    Console.Write("Nome Completo: ");
                    nomes[TL] = Console.ReadLine();

                    String emailTemp;
                    bool emailDuplicado;

                    do
                    {
                        emailDuplicado = false;
                        Console.Write("Email: ");
                        emailTemp = Console.ReadLine();

                        if (buscar_contato(emails, emailTemp, TL) != -1)
                        {
                            Console.WriteLine("\n* * * Email já cadastrado. Digite outro. * * *\n");
                            emailDuplicado = true;
                        }

                    } while (emailDuplicado);

                    emails[TL] = emailTemp;

                    TL++;

                    Console.WriteLine("\n* * * Contato Inserido com Sucesso! * * *\n");

                    Console.Write("Aperte [ESC] para voltar... ");
                    option = Console.ReadKey().Key;
                }
                while (option != ConsoleKey.Escape && TL < Program.MR);
            }
        }

        static void alterar_contato(ref String[] nomes, ref String[] emails, int TL)
        {
            if (TL == 0)
            {
                Console.WriteLine("* * * Nenhum Contato Registrado * * *\n");
                Console.ReadKey();
            }
            else
            {
                String email;
                ConsoleKey option;

                do
                {
                    Console.Clear();
                    Console.WriteLine("# # # ---- Alterar Contato ---- # # #\n");

                    Console.Write("Informe o email do Contato a ser Alterado: ");
                    email = Console.ReadLine();

                    int pos = buscar_contato(emails, email, TL);

                    if (pos == -1)
                        Console.WriteLine("\n* * * Contato não encontrado * * *\n");

                    else
                    {
                        Console.Write("\nNome: ");
                        nomes[pos] = Console.ReadLine();

                        String novoEmail;
                        bool emailOk;

                        do
                        {
                            emailOk = false;
                            Console.Write("\nEmail: ");
                            novoEmail = Console.ReadLine();

                            int posNovo = buscar_contato(emails, novoEmail, TL);

                            if (posNovo != -1 && posNovo != pos)
                            {
                                Console.WriteLine("\n* * * Email já cadastrado. Digite outro. * * *\n");
                                emailOk = true;
                            }

                        } while (emailOk);

                        emails[pos] = novoEmail;

                        Console.WriteLine("\n* * * Contato Alterado com Sucesso! * * *\n");
                    }

                    Console.Write("Aperte [ESC] para voltar... ");
                    option = Console.ReadKey().Key;
                }
                while (option != ConsoleKey.Escape);
            }
        }

        static void remover_contato(ref String[] nomes, ref String[] emails, ref int TL)
        {
            String email;
            ConsoleKey option;

            if (TL == 0)
            {
                Console.WriteLine("* * * Nenhum Contato Registrado * * *\n");
                Console.ReadKey();
            }
            else
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("# # # ---- Remover Contato ---- # # #\n");

                    Console.Write("Informe o email do Contato a ser Removido: ");
                    email = Console.ReadLine();

                    int pos = buscar_contato(emails, email, TL);

                    if (pos == -1)
                        Console.WriteLine("\n* * * Contato não encontrado * * *\n");

                    else
                    {
                        while (pos < TL - 1)
                        {
                            nomes[pos] = nomes[pos + 1];
                            emails[pos] = emails[pos + 1];
                            pos++;
                        }

                        Console.WriteLine("\n* * * Contato Removido com Sucesso! * * *\n");
                        TL--;
                    }

                    Console.Write("Aperte [ESC] para voltar... ");
                    option = Console.ReadKey().Key;
                }
                while (option != ConsoleKey.Escape);
            }
        }

        static void mostrar_contato(String[] nomes, String[] emails, int TL)
        {
            Console.WriteLine("# # # ---- Mostrar Contato(s) ---- # # #\n");

            if (TL == 0)
                Console.WriteLine("* * * Nenhum Contato Registrado * * *\n");

            else
                for (int i = 0; i < TL; i++)
                    Console.Write($" * #{i + 1} Nome: {nomes[i]} Email: {emails[i]}\n");

            Console.ReadKey();
        }

        static void aspirar_contato(String[] nomes, String[] emails, int TL)
        {
            if (TL == 0)
            {
                Console.WriteLine("* * * Nenhum Contato Registrado * * *\n");
                Console.ReadKey();
            }
            else
            {
                String email;
                ConsoleKey option;

                do
                {
                    Console.Clear();
                    Console.WriteLine("# # # ---- Aspirar Contato ---- # # #\n");

                    Console.Write("Informe o email do Contato a ser consultado: ");
                    email = Console.ReadLine();

                    int pos = buscar_contato(emails, email, TL);

                    if (pos == -1)
                        Console.WriteLine("\n* * * Contato não encontrado * * *\n");

                    else
                        Console.WriteLine($"\n * #{pos+1} Nome: {nomes[pos]} Email: {emails[pos]}\n");

                    Console.Write("Aperte [ESC] para voltar... ");
                    option = Console.ReadKey().Key;
                }
                while (option != ConsoleKey.Escape);
            }
        }

        static ConsoleKey Menu()
        {
            Console.Clear();

            Console.WriteLine("# # # ---- Menu ---- # # #\n");

            Console.WriteLine("[a] - Inserir Contato(s)");
            Console.WriteLine("[b] - Alterar Contato(s)");
            Console.WriteLine("[c] - Remover Contato(s)");
            Console.WriteLine("[d] - Mostrar Contato(s)");
            Console.WriteLine("[e] - Aspirar Contato(s)");
            Console.WriteLine("[ESC] - Finalizar");

            Console.Write("\nEscolha uma opção: ");
            return Console.ReadKey().Key;
        }

        static void Main(string[] args)
        {
            // # # # --- Variáveis --- # # # //
            String[] nomes = new String[Program.MR];
            String[] emails = new String[Program.MR];
            int TL = 0;
            ConsoleKey option;

            // Carregar dados do Arquivo
            Backup.filename = "agenda.txt";
            Backup.restaurar(ref nomes, ref emails, ref TL);

            do
            {
                option = Menu(); // Pegar Opção desejada
                Console.Clear(); // Limpar Terminal para Função

                switch(option)
                {
                    case ConsoleKey.A: inserir_contato(ref nomes, ref emails, ref TL); break;
                    case ConsoleKey.B: alterar_contato(ref nomes, ref emails, TL); break;
                    case ConsoleKey.C: remover_contato(ref nomes, ref emails, ref TL); break;
                    case ConsoleKey.D: mostrar_contato(nomes, emails, TL); break;
                    case ConsoleKey.E: aspirar_contato(nomes, emails, TL); break;
                }
            }
            while (option != ConsoleKey.Escape);

            Backup.salvar(ref nomes, ref emails, TL);
        }
    }
}