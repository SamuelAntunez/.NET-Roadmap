
Operation mySum = Functions.Sum;

Console.WriteLine(mySum(1,2));

#region Action
Action<string> showMessage = Console.WriteLine;
Action<string, string> showMessage2 = (a, b) => Console.WriteLine(a + b);
showMessage("Hola Mundo");
#endregion

#region Predicate
Predicate<string> hasSpace = (word) => word.Contains(" ");
Console.WriteLine(hasSpace("Hello World"));
#endregion

#region Func
Func<int> numberRandom = () => new Random().Next(1, 100);
Console.WriteLine(numberRandom());
Func<int, int>numberRandomLimit = (limit) => new Random().Next(1, limit);
Console.WriteLine(numberRandomLimit(10));
#endregion

#region Delegados
delegate int Operation(int a, int b);
public delegate void Show(string message);
# endregion


public class Functions
{
    public static int Sum(int a, int b) => a + b;
    public static int Mul(int a, int b) => a * b;

    public static void ConsoleShow(string message) => Console.WriteLine(message);

    public static void Some(string name, string lastName, Show fn)
    {
        Console.WriteLine("Hago algo al inicio");
        fn($"Hola {name} {lastName}");
        Console.WriteLine("Hago algo al Final");

    }
}

