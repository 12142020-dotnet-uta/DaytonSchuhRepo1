using System;
using System.Collections.Generic;

namespace CollectionsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generic Collections
            Console.WriteLine("Generating Generic Examples...\n##################################");

            // Declare a list object
            List<string> stringList = new List<string>();

            // Populate the list
            for (int i = 1; i < 11; i++)
            {
                stringList.Add(i.ToString());
            }

            // Cycle through the list and print our position and the string contained at that index
            foreach (string s in stringList)
            {
                Console.WriteLine($"Position {stringList.IndexOf(s) + 1 } in our string list contains the string: \"{s}\"");
            }

            Console.WriteLine("##################################");


            /****************************************************************************
            * The following code is rough. 
            * Using 'ToArray' nullifies the point of making an example for non-generic
            * collections
            ****************************************************************************/

            // Non-Generic Collections
            Console.WriteLine("Generating Non-Generic Examples...\n##################################");

            // Declare a queue object
            Queue<string> que = new Queue<string>();

            // Add things to the queue
            for (int i = 1; i < 11; i++)
            {
                que.Enqueue(i.ToString());
                Console.WriteLine($"Enqueuing item {i}.\n\tItem {i} type: {i.GetType().Name}\n\tItem {i} position in queue: {Array.IndexOf(que.ToArray(), i.ToString()) + 1}");
            }

            string str;
            // As long as there is something in the queue...
            while (que.TryPeek(out str))
            {
                que.TryDequeue(out str);
                Console.WriteLine($"Dequeued item {str}.");
                int count = 0;
                while (que.ToArray().Length > count)
                {
                    Console.WriteLine($"\tItem {que.ToArray().GetValue(count)} new position in queue: {Array.IndexOf(que.ToArray(), que.ToArray().GetValue(count).ToString())}");
                    count++;
                }
            }
            Console.WriteLine("##################################");

        }
    }
}
