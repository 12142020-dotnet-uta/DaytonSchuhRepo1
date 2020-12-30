using System;
using System.Collections.Generic;

namespace P0_DaytonSchuh
{
    class Program
    {
        static StoreRepoLayer storeContext = new StoreRepoLayer();
        /**********************************************
        *
        * Main
        *
        ***********************************************/
        static void Main(string[] args)
        {
            Test test = new Test();
            if (test.TestAll())
                storeContext.Start();
            else
            {
                Console.Clear();
                Console.WriteLine("Check to make sure that all tests pass.");
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
            }
            int command;
            while (true)
            {

                string input = System.Console.ReadLine();
                int.TryParse(input, out command);
                try
                {
                    storeContext.Navigate(command);
                }
                catch (NullReferenceException)
                {
                    System.Console.WriteLine("An error occured.");
                }

            }
        }// END Main


    }// END class


}// END namespace
