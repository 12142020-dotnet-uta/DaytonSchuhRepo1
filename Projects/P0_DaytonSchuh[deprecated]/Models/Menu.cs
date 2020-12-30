using System;

namespace P0_DaytonSchuh
{
    public class Menu : MenuInterface
    {
        public string[] menus = {
            /* menus[0] == Main menu */
            "------------------------------------------------------------\n" +
            "|                Welcome To Risky Business!                |\n" +
            "------------------------------------------------------------\n" +
            "| Enter the integer corresponding to your desired command. |\n" +
            "------------------------------------------------------------\n" +
            "|     1. Login     |     2. Register     |     3. Quit     |\n" +
            "------------------------------------------------------------",
            /* menus[1] == Login menu */
            "------------------------------------------------------------\n" +
            "|                 Login To Risky Business!                 |\n" +
            "------------------------------------------------------------\n" +
            "|          Follow the directions below to login!           |\n" +
            "------------------------------------------------------------",
            /* menus[2] == Register menu */
            "------------------------------------------------------------\n" +
            "|               Register with Risky Business!              |\n" +
            "------------------------------------------------------------\n" +
            "|         Follow the directions below to register!         |\n" +
            "------------------------------------------------------------",
            /* menus[3] == Store menu */
            "------------------------------------------------------------\n" +
            "|            Risky Business is the place to be!            |\n" +
            "------------------------------------------------------------\n" +
            "|          Choose a store to browse our inventory!         |\n" +
            "------------------------------------------------------------",
            /* menus[4] == Inventory menu */
            "------------------------------------------------------------\n" +
            "|           You're shopping with Risky Business!           |\n" +
            "------------------------------------------------------------\n" +
            "| Enter the integer corresponding to your desired command. |\n" +
            "------------------------------------------------------------\n" +
            "|    1. Add Item    |    2. View Cart    |   3. Go Back    |\n" +
            "------------------------------------------------------------",
            /* menus[5] == Cart menu */
            "------------------------------------------------------------\n" +
            "|                You're viewing your cart!                 |\n" +
            "------------------------------------------------------------\n" +
            "| Enter the integer corresponding to your desired command. |\n" +
            "------------------------------------------------------------\n" +
            "|     1. Login     |     2. Register     |  3. Total Cost  |\n" +
            "------------------------------------------------------------",
            /* menus[6] == Quit */
            "Thanks for stopping by!"
            };
        public void Display(string message)
        {
            //Console.Clear();
            Console.WriteLine(message);
        }
    }
}