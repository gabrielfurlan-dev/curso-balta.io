
using System.Text;
using System.Text.RegularExpressions;

namespace HTMLTextEditor
{
    public class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            System.Console.WriteLine("MODO EDITOR");
            System.Console.WriteLine("=============");
            Start();
        }

        private static void Start()
        {
            var text = new StringBuilder();

            do
            {
                text.Append(Console.ReadLine() + " ");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            System.Console.WriteLine("Deseja salvar o arquivo?");
            Console.ReadLine();
            Viewer.View(text.ToString());
        }
    }

    public class Viewer
    {
        public static void View(string text)
        {
            System.Console.WriteLine("MODO VISUALIZADOR");
            System.Console.WriteLine("=================");
            Replace(text);
            System.Console.WriteLine("=================");
            System.Console.WriteLine("Deseja sair:");
            Console.ReadKey();
            Menu.Show();
        }

        static void Replace(string text)
        {
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            var words = text.Split(" ");

            for (int i = 0; i < words.Length; i++)
            {
                if (strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(words[i].Substring(words[i].IndexOf(">") + 1, (words[i].LastIndexOf("<") - 1) - words[i].IndexOf(">")) + " ");

                    Console.ForegroundColor = ConsoleColor.Black;
                }else
                    Console.Write(words[i] + " ");
            }
        }
    }
}