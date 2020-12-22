using System;
/*

To run the program, simply open a terminal in the correct directory and use the command: dotnet run

*/
namespace HelloWorldExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 9;
            double j = 0.2;
            // We can output to console by using Console.WriteLine
            Console.WriteLine(++i/j-i++);
        }
    }
}
