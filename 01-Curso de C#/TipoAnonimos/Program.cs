namespace TipoAnonimos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var samuel = new
            {
                Name = "Samuel",
                Country = "Venezuela"
            };

            Console.WriteLine($"{samuel.Name} {samuel.Country}");
        }
    }
}
