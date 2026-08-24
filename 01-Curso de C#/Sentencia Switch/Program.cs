namespace Sentencia_Switch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int op = 1;

            switch (op)
            {
                case 1:
                    Console.WriteLine("Seleccionaste el 1");
                    break;
                case 2:
                    Console.WriteLine("Seleccionaste el 2");
                    break;
                case 3:
                case 4:
                    Console.WriteLine("Opcion 3 o 4 anidada");
                    break;
                default:
                    Console.WriteLine("Invalido");
                    break;
            }
        }
    }
}
