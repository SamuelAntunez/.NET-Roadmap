namespace Tuplas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (int id, string name) product = (1, "Cerveza stout");
            Console.WriteLine($"{product.id} {product.name}");
            var person = (1, "Samuel");
            Console.WriteLine($"persona {person.Item1} {person.Item2}");
        }
    }
}
