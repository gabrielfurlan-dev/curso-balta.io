using System;

namespace TextEditor
{
    internal class TextEditor
    {
        static void Main(string[] args)
        {
            ExibirOpcoes();
        }
        
        public static void ExibirOpcoes()
        {
            Console.Clear();
            System.Console.WriteLine("Selecione uma das opções");
            System.Console.WriteLine("[ 1 ] - Abrir Arquivo");
            System.Console.WriteLine("[ 2 ] - Criar novo arquivo");
            System.Console.WriteLine("[ 0 ] - Sair");
            short opcao = short.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1: AbrirArquivo(); break;
                case 2: CriarNovoArquivo(); break;
                case 0: Environment.Exit(0); break;
                default: ExibirOpcoes(); break;
            }

        }

        static void AbrirArquivo()
        {
            Console.Clear();
            System.Console.WriteLine("Digite o caminho do arquivo a ser lido:");
            var path = Console.ReadLine();

            using (var arquivo = new StreamReader(path))
            {
                try
                {
                    var texto = arquivo.ReadToEnd();
                    System.Console.WriteLine(texto);
                    Console.Write(Environment.NewLine + "Digite algo para sair. . .");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.Write("Ops! Algo deu errado.");
                    System.Console.WriteLine("Talvez você digitou o caminho incorreto ou o arquivo não existe.");
                    Console.Write(Environment.NewLine + "Digite algo para sair. . .");
                    Console.ReadLine();
                }
            }

            ExibirOpcoes();
        }

        static void CriarNovoArquivo()
        {
            Console.Clear();
            Console.WriteLine("NovoArquivo.txt");
            Console.WriteLine("--------------------------------------");
            var texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;

            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            SalvarArquivo(texto);
        }

        static void SalvarArquivo(string texto)
        {
            Console.Clear();
            System.Console.WriteLine("aDigite o caminho de saída do arquivo");
            var path = Console.ReadLine();

            using (var arquivo = new StreamWriter(path))
            {
                try
                {
                    arquivo.Write(texto);

                    Console.WriteLine("Arquivo salvo com sucesso!");
                    System.Console.WriteLine("Digite algo para sair. . .");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Ops! Parece que você digitou um caminho errado ou esqueceu de colocar o nome do arquivo e sua extensão.");
                    System.Console.WriteLine("Digite algo para continuar. . .");
                    Console.ReadLine();
                }
            }

            ExibirOpcoes();
        }
    }
}