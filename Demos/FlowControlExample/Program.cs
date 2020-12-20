using System;

namespace FlowControlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring string we will use for demonstration
            string str;

            // Do While loop always runs at least once...
            do
            {
                // Prompt user for input
                Console.WriteLine("Please enter a single number, or 'q' to quit: ");
                // Store user input into string object
                str = Console.ReadLine();

                // Declare integer we will use to catch TryParse value
                int n;

                // TryParse returns a boolean, which makes it effective for
                // validating input you may want to use (in our example, it's integer n)
                if (int.TryParse(str, out n))
                {

                    // Pick which code to run based on our input!
                    switch (n)
                    {
                        case 0:
                            Console.WriteLine("From zero to hero!");
                            break;
                        case 1:
                            Console.WriteLine("You'll always be number one in my heart.");
                            break;
                        case 2:
                            Console.WriteLine("You're second to none!");
                            break;
                        case 3:
                            Console.WriteLine("Third times the charm!");
                            break;
                        case 4:
                            Console.WriteLine("There's only one thing to say, three words for you. I love you.");
                            break;
                        default:
                            Console.WriteLine("Nine ladies dancing, Eight maids a-milking, Seven swans a-swimming, Six geese a-laying, Five golden rings");
                            break;
                    }
                }
                // If the user wants to quit...
                else if (str == "q")
                {
                    Console.WriteLine("Thanks for playing with me!");
                }
                // Silly user. You don't know anything.
                else
                {
                    Console.WriteLine("That wasn't a valid input, you silly goose.");
                }
            } while (str != "q");
            // We're free from this god forsaken hell.
        }
    }
}
