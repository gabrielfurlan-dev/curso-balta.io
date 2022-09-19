
namespace StopWatch
{
    public class StopWatch
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================");
            Console.WriteLine("Enter duration time stopwatch");
            Console.WriteLine("add sufix S or M in the end of line");
            Console.WriteLine("Exemple: \"10s\" to ten seconds or \"10m\" to ten minutes");
            string input = Console.ReadLine().ToLower();
            char type = Char.Parse(input.Substring(input.Length - 1, 1));
            int time = int.Parse(input.Substring(0, input.Length - 1));
            PreStart();
            if (type == 's')
            {
                Start(time);
            }
            else if(type == 'm')
            {
                Start(time * 60);
            }
        }

        static void Start(int time)
        {
            for (int i = 0; i < time + 1; i++)
            {
                Console.Clear();
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("End time!");
            Environment.Exit(0);
        }

        static void PreStart()
        {
            Console.WriteLine("Read.");
            Thread.Sleep(1000);
            Console.WriteLine("Set.");
            Thread.Sleep(1000);
            Console.WriteLine("Go!!");
            Thread.Sleep(1000);
        }
    }
}