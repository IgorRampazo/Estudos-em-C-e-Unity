using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Drawing;

namespace BichinhoVirtual
{
    internal class Program
    {
        // [Inicio] - Imagem

        static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            // Cria um novo Bitmap com a largura e altura desejadas
            Bitmap resizedImage = new Bitmap(width, height);

            // Desenha a imagem original no novo Bitmap usando as dimensões desejadas
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }

            return resizedImage;
        }

        static string ConvertToAscii(Bitmap image)
        {
            // Caracteres ASCII usados para representar a imagem
            char[] asciiChars = { ' ', '.', ':', '-', '=', '+', '*', '#', '%', '@' };

            StringBuilder asciiArt = new StringBuilder();

            // Percorre os pixels da imagem e converte cada um em um caractere ASCII correspondente
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int grayScale = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int asciiIndex = grayScale * (asciiChars.Length - 1) / 255;
                    char asciiChar = asciiChars[asciiIndex];
                    asciiArt.Append(asciiChar);
                }
                asciiArt.Append(Environment.NewLine);
            }

            return asciiArt.ToString();
        }

        static void ExibirImagem(string imagePath, int width, int height)
        {
            // Caminho para a imagem que deseja exibir
            //string imagePath = @"C:\Users\Danilo Filitto\Downloads\Panda.jpg";

            // Carrega a imagem
            Bitmap image = new Bitmap(imagePath);

            // Redimensiona a imagem para a largura e altura desejadas
            int consoleWidth = width;
            int consoleHeight = height;
            Bitmap resizedImage = ResizeImage(image, consoleWidth, consoleHeight);

            // Converte a imagem em texto ASCII
            string asciiArt = ConvertToAscii(resizedImage);

            // Exibe o texto ASCII no console
            Console.WriteLine(asciiArt);


        }

        // [Fim] - Imagem

        static void salvar(string filename, string bicho, string dono, string alimentado, string limpo, string feliz)
        {
            File.WriteAllLines(filename, new string[]
            {
                bicho,
                dono,
                alimentado,
                limpo,
                feliz
            });
        }

        static void carregarDados(string filename, ref float alimentado, ref float limpo, ref float feliz)
        {
            string[] dados = File.ReadAllLines(filename);

            alimentado = float.Parse(dados[2]);
            limpo = float.Parse(dados[3]);
            feliz = float.Parse(dados[4]);

            if (alimentado <= 0 || limpo <= 0 || feliz <= 0)
            {
                Console.WriteLine("\nAssistente Virtual:\n");
                Console.WriteLine("Seu bichinho está muito fraco!!!");
                Console.WriteLine("Vamos cuidar dele para você!!!");
                Console.WriteLine("Pronto, ele está saudável e feliz.");
                Console.WriteLine("\nPressione qualquer tecla para continuar...");

                Console.ReadKey();

                alimentado = 100;
                limpo = 100;
                feliz = 100;
            }
        }

        static string Falar(Random rand)
        {
            string[] frases = new string[]
            {
                "Nossa, o dia foi muito legal! Comi o sofá!",
                "Que saudades! Passei o dia todo esperando você chegar!",
                "Hoje assisti ao Show da Xuxa."
            };

            return frases[rand.Next(frases.Length)];
        }

        static void AtualizarStatus(Random rand, ref float alimentado, ref float limpo, ref float feliz)
        {
            int caracteristica = rand.Next(3);

            switch (caracteristica)
            {
                case 0: alimentado -= rand.Next(40); break;
                case 1: limpo -= rand.Next(40); break;
                case 2: feliz -= rand.Next(40); break;
            }

            if (alimentado < 0) alimentado = 0;
            if (limpo < 0) limpo = 0;
            if (feliz < 0) feliz = 0;
        }

        static string Input(string texto)
        {
            Console.Write(texto);
            return Console.ReadLine();
        }

        static string InteragirComBichinho(string nome_dono, Random rand, ref float alimentado, ref float limpo, ref float feliz)
        {
            Console.WriteLine($"{nome_dono}, o que vamos fazer hoje?");
            string entrada = Input("Brincar / Comer / Banho / Nada: ").ToLower();

            switch (entrada)
            {
                case "brincar": feliz += rand.Next(30); break;
                case "comer": alimentado += rand.Next(30); break;
                case "banho": limpo += rand.Next(30); break;
            }

            if (alimentado > 100) alimentado = 100;
            if (limpo > 100) limpo = 100;
            if (feliz > 100) feliz = 100;

            return entrada;
        }

        static void Main(string[] args)
        {
            string nome_bicho = "";
            string nome_dono = "";
            string entrada = "";

            Random rand = new Random();

            float alimentado = 100;
            float limpo = 100;
            float feliz = 100;

            string photopath = Path.Combine(Environment.CurrentDirectory, "banguela.png");

            Console.WriteLine("MEU BICHINHO VIRTUAL\n");

            if (File.Exists(photopath))
            {
                try
                {
                    ExibirImagem(photopath, 5, 5);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao exibir imagem ASCII: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Imagem não encontrada. Pulando exibição de imagem.");
            }

            nome_bicho = Input("Informe o nome do seu bichinho: ");
            Console.WriteLine("teste");
            nome_dono = Input("Oi, qual o nome do meu dono? ");
            string filename = $"{nome_bicho}_{nome_dono}.txt";

            Console.WriteLine($"Legal, estava com muita saudade de você, {nome_dono}!");

            if (File.Exists(filename))
                carregarDados(filename, ref alimentado, ref limpo, ref feliz);

            do
            {
                Console.Clear();
                Console.WriteLine($"\nStatus do {nome_bicho}:\n");
                Console.WriteLine($"Alimentado: {alimentado}");
                Console.WriteLine($"Limpo: {limpo}");
                Console.WriteLine($"Feliz: {feliz}\n");

                Console.Write("\nPressione qualquer tecla para continuar... ");
                Console.ReadKey();

                AtualizarStatus(rand, ref alimentado, ref limpo, ref feliz);

                Console.Clear();
                Console.WriteLine($"Olá, {nome_dono}!");
                Console.WriteLine(Falar(rand) + "\n");

                if (alimentado > 30 && alimentado < 75)
                {
                    Console.WriteLine("Estou faminto!!!");
                    Console.WriteLine("Nada melhor que uma comidinha...");
                }
                if (limpo > 30 && limpo < 75)
                {
                    Console.WriteLine("Estou sujinho!!!");
                    Console.WriteLine("Nada melhor que um banhozinho...");
                }
                if (feliz > 30 && feliz < 75)
                {
                    Console.WriteLine("Fiquei em casa o dia todo!!!");
                    Console.WriteLine("Nada melhor que brincar...");
                }

                Thread.Sleep(2000);
                Console.Clear();

                entrada = InteragirComBichinho(nome_dono, rand, ref alimentado, ref limpo, ref feliz);

            } while (entrada != "nada" && alimentado > 0 && limpo > 0 && feliz > 0);

            salvar(filename, nome_bicho, nome_dono, alimentado.ToString(), limpo.ToString(), feliz.ToString());

            Console.Clear();
            if (alimentado <= 0 || limpo <= 0 || feliz <= 0)
            {
                Console.WriteLine($"{nome_dono}, estou morrendo...");
                Console.WriteLine("Você não cuidou de mim. Te vejo na próxima vida!!!");
            }
            else
            {
                Console.WriteLine($"{nome_dono}, não vejo a hora de brincar com você novamente.");
                Console.WriteLine("Volte logo!!!");
            }

            Console.ReadKey();
        }
    }
}