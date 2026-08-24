namespace Arreglos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] friends = new string[7]
            {
                "Juan",
                "paco",
                "Ana",
                "Ruben",
                "Karla",
                "Luis", 
                null
            };
            friends[6] = "Samuel";

            Console.WriteLine(friends[0]);
            Console.WriteLine(friends[5]);
        }
    }
}
