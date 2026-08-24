namespace SentenciaIfElseIf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool areYouHungry = true;
            bool youHaveMoney = false;

            if (areYouHungry && youHaveMoney && IsOpenRestaurant("Lonches pepe", 11))
            {
                Console.WriteLine("Come");
            }
            else
            {
                Console.WriteLine("No comes");
            }
        }

        static bool IsOpenRestaurant(string name, int hour = 0)
        {
            if(name == "Lonches pepe" && hour > 5)
            {
                return true;
            }
            else if(name == "Restaurant 24 horas")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
