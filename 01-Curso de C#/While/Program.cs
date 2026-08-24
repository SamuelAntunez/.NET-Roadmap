namespace While
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

            while (i < 10)
            {
                Console.WriteLine("Iteracion de i " + i);
                //i = i + 1;
                i++;
            }

            int j = 0;
            while (j < 100)
            {
                if (j > 10)
                    break; // Romper el bucle

                Console.WriteLine("Iteracion de i " + j);
                //i = i + 1;
                j++;
            }

            bool run = false;
            do
            {
                Console.WriteLine("entro una vez y ya");
            }
            while (run);
        }
    }
}
