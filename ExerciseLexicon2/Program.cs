using System;
using static ExerciseLexicon2.Utilities;    //adding library of utilities, the methods.
using static ExerciseLexicon2.AgeGroupCounters;
using static ExerciseLexicon2.MainMenu;
namespace ExerciseLexicon2
    

{
    public class Program
    {
       
        static void Main(string[] args)                                                                    // Start of main program
        {
            Console.WriteLine("Hello, you are in the Main Menu, please use numbers to navigate. ");        // Note: Should initialize with a method maybe to make it clear 
                                                                                                           // Main Menu Message
            while (true)                                                                                   // Infinite loop of a menu
            {
                MainMenu.Display();                                                                        // Displaying the Main Menu class
                var choice = MainMenu.GetUserChoice();                                                     // Reading off customer input

                switch (choice)                                                                            // Switch menu
                {
                    case "0":                                                                              // Choice of closing the application
                        ProgramExit();
                        break;

                    case "1":                                                                              // Menu choice 1, checking the age of the customer nad repsective age group
                        AgeCheck();
                        break;

                    case "2":                                                                              // Menu choice 2, checking the cost for the entire group
                        GroupCalculation();
                        break;

                    case "3":                                                                              // Menu choice 3, printing customer message 10 times in a row.
                        CustomerMessage();
                        break;

                    case "4":                                                                              // Menu choice 4, fishing out the third word in a sentence of the user
                        CustomSplitter();
                        break;

                    default:                                                                               // Default choice, starting menu over
                        break;

                }
            }
        }
    }
}