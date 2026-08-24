using System.Collections.Generic;

namespace Listas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.Add(5);
            numbers.Add(2);

            Console.WriteLine(numbers.Count);

            List<int> numbers2 = new List<int>()
            {
                1,2,3,6
            };

            foreach (var number in numbers2)
            {
                Console.WriteLine("for each " + number);
            }

            List<People> students = new List<People>()
            {
                new People() { Name = "Hector", Country = "Pais"},
                new People() { Name = "Ra", Country = "Pais"},
                new People() { Name = "RE", Country = "Pais"}

            };

            static void Show(List<People> students)
            {
                Console.WriteLine("--Personas--");
                foreach (var people in students)
                {
                    Console.WriteLine($"Nombre: {people.Name}, Pais: {people.Country}");
                }
            }

            Show(students);

            numbers2.Clear();
            Console.WriteLine(numbers2.Count);

            List<string> countries = new List<string>()
            {
                "mexico", "argentina", "venezuela"
            };

            students.RemoveAt(0);
        }

        class People
        {
            public string Name { get; set; }

            public string Country { get; set; }
        }
    }
}
