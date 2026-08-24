namespace Propiedades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        class Sale
        {
            int total;
            DateTime date;

            public int Total
            {
                get
                {
                    return total;
                }
                set
                {
                    if (value < 0) value = 0;
                    total = value;
                }
            }

            public Sale(int total, DateTime date)
            {
                this.total = total;
                this.date = date;
            }

        }
         
    }
}
