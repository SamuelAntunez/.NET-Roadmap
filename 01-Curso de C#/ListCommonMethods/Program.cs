

using System.Globalization;

namespace ListCommonMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> number = new List<int>()
            {
                4,3,5,19
            };

            int element = 5;

            Show(number);

            number.Insert(0, 6);
            number.Contains(33);
            number.IndexOf(19);
            number.Sort();
            number.AddRange(new List<int>()
            {
                200, 500, 400
            });


        }

        public static void Show(List<int> numbers)
        {
            foreach(var n in numbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}
