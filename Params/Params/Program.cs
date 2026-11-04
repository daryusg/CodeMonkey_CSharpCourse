namespace Params
{
    //params

    internal class Program
    {
        static void Main(string[] args)
        {
            PrintPlayerName(1990, "Alice");
            PrintPlayerName(1991, "Bob", "Charlie");
            PrintPlayerName(1992, "David", "Eve", "Frank");
        }

        //NOTE: The params keyword allows you to pass a variable number of arguments to a method.
        //It must be the last parameter in the method signature, and it can only be used once in a method.
        //it must be an array type. eg List<string> names will not work
        private static void PrintPlayerName(int year, params string[] names)
        {
            Console.WriteLine($"{year} - Player names are: {string.Join(", ", names)}");
        }

        //private static void PrintPlayerName(string name, string name2)
        //{
        //    Console.WriteLine($"Player names are: {name} and {name2}");
        //}
        //private static void PrintPlayerName(string name, string name2, string name3)
        //{
        //    Console.WriteLine($"Player names are: {name}, {name2}, and {name3}");
        //}
    }
}
