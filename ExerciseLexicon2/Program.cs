using System;
using static ExerciseLexicon2.Utilities;
namespace ExerciseLexicon2
    

{
    public class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, you are in the Main Menu, please use numbers to navigate. ");

            while (true)
            {
                Console.WriteLine("\n\nPlease make your choice: ");
                Console.WriteLine("\n0. Close the application");
                Console.WriteLine("1. Check your age and the price ");
                Console.WriteLine("2. Calculate the total cost for your group ");
                Console.WriteLine("3. I will print your message 10 times, try me! ");
                Console.WriteLine("4. I will split your sentence and draft out the word for you! ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Closing the application down, thank you.");
                        Environment.Exit(0);
                        break;

                    case "1":
                        AgeCheck();
                        break;
                    case "2":
                        int customerCount = CustomerGroup();
                        CustomerAges(customerCount, 0);
                        Console.WriteLine($"Total Cost for the group: {CalculateTotalCost()}kr");
                        break;
                    case "3":
                        CustomerMessage();
                        break;

                    case "4":
                        CustomSplitter();
                        break;

                    default:
                        Environment.Exit(1);
                        break;

                }
            }
        }
    }
}