using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLexicon2
{
    internal class MainMenu                                                  // Creating a helper class to keep the Program.cs tidy and easier to manage
    {

        private static readonly string[] MenuOptions = new[]                 // Main menu, note that there is a comma separating every each line
        {
        "0. Close the application",
        "1. Check your age and the price",
        "2. Calculate the total cost for your group",
        "3. I will print your message 10 times, try me!",
        "4. I will split your sentence and draft out the word for you!"
        };

        public static void Display()                                         // Display method for the main menu
        {
            Console.WriteLine("\n\nPlease make your choice: ");

            foreach (var menuOption in MenuOptions)                          // Choosing the appropriate menu position from the user in accordance to the input
            {
                Console.WriteLine(menuOption);
            }
        }
        public static string GetUserChoice()                                 // Reading off user input for the main menu
        {
            return Console.ReadLine()!;
        }
    }
}
