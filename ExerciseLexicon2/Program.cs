﻿using System;
using static ExerciseLexicon2.Utilities;    //adding library of utilities, the methods.
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
                Console.WriteLine("\n\nPlease make your choice: ");                                        // Note: Maybe could make interface out of this?
                Console.WriteLine("\n0. Close the application");                                           // Menu display options
                Console.WriteLine("1. Check your age and the price ");                                     // Menu display options
                Console.WriteLine("2. Calculate the total cost for your group ");                          // Menu display options
                Console.WriteLine("3. I will print your message 10 times, try me! ");                      // Menu display options
                Console.WriteLine("4. I will split your sentence and draft out the word for you! ");       // Menu display options

                var choice = Console.ReadLine();                                                           // Reading off customer input
                switch (choice)                                                                            // Switch menu
                {
                    case "0":                                                                              // Choice of closing the application
                        Console.WriteLine("Closing the application down, thank you.");                     // Note: Should initialize it with a method maybe?
                        Environment.Exit(0);
                        break;

                    case "1":                                                                              // Menu choice 1, checking the age of the customer nad repsective age group
                        AgeCheck();
                        break;

                    case "2":                                                                              // Menu choice 2, checking the cost for the entire group
                        int customerCount = CustomerGroup();
                        CustomerAges(customerCount);
                        Console.WriteLine($"Amount of people: {customerCount}\n" +
                                          $"Total Cost for the group: {CalculateTotalCost()}kr");
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