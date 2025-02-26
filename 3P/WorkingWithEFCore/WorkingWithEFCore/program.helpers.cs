partial class Program
{
        static void Sectiontitle(string title)
        {
            ConsoleColor backgroundColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("*");
            WriteLine($"{title}");
            WriteLine("*");
            ForegroundColor = backgroundColor;
        }


        static void Fail(string message)
        {
            ConsoleColor backgroundColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"Info > {message}");
            ForegroundColor = backgroundColor;
        }
        
        static void Info(string message)
        {
            ConsoleColor backgroundColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Blue;
            WriteLine($"Info > {message}");
            ForegroundColor = backgroundColor;
        }
}