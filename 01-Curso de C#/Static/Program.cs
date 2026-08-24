namespace Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            People people1 = new People()
            {
                Name = "Samuel",
                Age = 34,
            };

            Console.WriteLine(People.Count);
        }

        public class People
        {
            public static int Count = 0;
            public string Name { get; set; }
            public int Age { get; set; }
        }


    }
}
