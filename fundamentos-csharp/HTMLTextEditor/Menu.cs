using System.Text;

namespace HTMLTextEditor
{
    public static class Menu
    {
        public static void Show()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public static void DrawScreen(int length)
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine(FillLine(length, "+", "-"));
            text.AppendLine(FillLine(length, "|", " "));
            text.AppendLine(FillLine(length, "|", " "));
            text.AppendLine(FillLine(length, "|", " "));
            text.AppendLine(FillLine(length, "|", " "));
            text.AppendLine(FillLine(length, "|", " "));
            text.AppendLine(FillLine(length, "|", " "));
            text.AppendLine(FillLine(length, "|", " "));
            text.AppendLine(FillLine(length, "|", " "));
            text.AppendLine(FillLine(length, "+", "-"));

            Console.WriteLine(text);
        }

        public static string FillLine(int length, string yCharacter, string xCharacter)
        {
            string line = yCharacter;
            for (int index = 0; index < length; index++)
                line += xCharacter;
            line += yCharacter;

            return line;
        }

        public static void ShowOptionsMenu()
        {
            List<string> options = new List<string>();

            options.Add("HTML Text Editor");
            options.Add("================");
            options.Add("Options:");
            options.Add("[ 1 ] - Create HTML File");
            options.Add("[ 2 ] - Open HTML File");
            options.Add(" ");
            options.Add("[ 0 ] - Exit");

            WriteMenu(options, 3, 3);

            var option = Int32.Parse(Console.ReadLine());
            Choice(option);
        }

        public static void WriteMenu(List<string> options, int left, int topStart){

            for (int i = 0; i < options.Count - 1; i++)
            {
                WritePosition(options[i], left, topStart + i);
            }
            
        }

        public static void WritePosition(string texto, int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine(texto);
        }
    
        public static void Choice(int option)
        {
            switch(option)
            {
                case 1: Editor.Show(); break;
                case 2: break;
                case 0: Environment.Exit(0); break;
                default: ShowOptionsMenu(); break;
            }
        }
    }
}