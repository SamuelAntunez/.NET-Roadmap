namespace Funciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;

            Show();

            Sum(1, 2);

            int m = Mul(a, b);
        }

        static void Sum(int a, int b)
        {
            int c = a + b;
            Console.WriteLine(c);
        }

        static void Show()
        {
            Console.WriteLine("Hola, soy un texto que se imprime desde una function");
        }

        static int Mul(int a, int b)
        {
            int c = a * b;
            return c;
        }
    }
}
