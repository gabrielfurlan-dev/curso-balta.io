using System;

namespace calculadora;
public class Calculadora
{
    static void Main(string[] args)
    {
        if (!MostrarMenu()) return;

        System.Console.WriteLine("Digite o primeiro número: ");
        float num1 = float.TryParse(Console.ReadLine());

        System.Console.WriteLine("Digite o segundo número: ");
        float num2 = float.TryParse(Console.ReadLine());

        System.Console.WriteLine("Digite o segundo número: ");
        int operacao = Int32.TryParse(Console.ReadLine());

        if (operacao > 0 && operacao < 5)
        {
            RealizarOperacao(num1, num2, (EOperacao)operacao);
        }
    }

    public void RealizarOperação(float num1, float num2, EOperacao operacao)
    {
        return Eoperacao switch
        {
            Soma => num1 + num2,
            Subtracao => num1 + num2,
            Multiplicacao => num1 + num2,
            Divisao => num1 + num2,
            _ => null
        };
    }

    public bool MostrarMenu()
    {
        while (MostrarMenu)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("|==========|| Calculadora ||==========|");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("Selecione uma operação para continuar"
                                    + "[ 1 ] Soma"
                                    + "[ 2 ] Subtração"
                                    + "[ 3 ] Multiplicação"
                                    + "[ 4 ] Soma");

            string valor = Console.ReadLine();
        }
    }
public enum EOperacao
{
    // [Description("+")]
    Soma,
    // [Description("-")]
    Subtracao,
    // [Description("*")]
    Multiplicacao,
    // [Description("/")]
    Divisao
}
}

