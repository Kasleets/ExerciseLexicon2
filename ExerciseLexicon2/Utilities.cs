using Microsoft.Azure.Devices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ExerciseLexicon2.AgeGroupCounters;

namespace ExerciseLexicon2
{

    internal class Utilities                                                    // Gathering of all variables and methods in one space
    {
        public static AgeGroupCounters Counters = new AgeGroupCounters();       // Debug, if the menu is called multiple times to start with a fresh account

        public static void AgeCheck(int age = 0)                                // Menu choice: 1 AgeCheck method 
        {
            Console.WriteLine("Please state your age");
            string? aInput = Console.ReadLine();                                // Reading user input 

            int.TryParse(aInput, out age);                                      // Converting user input into an integer value
            var ageCategory = GetAgeCategory(age);                              // Receiving the age categories from enum
            switch (ageCategory)                                                // Defining switch menu based on the age croup respective to Price Constants cost of the menu
            {
                case AgeCategory.Invalid:
                    Console.WriteLine("Invalid age provided.");
                    break;
                case AgeCategory.Baby:
                    Console.WriteLine($"{PriceConstants.FreeEntry} ");
                    break;
                case AgeCategory.Youth:
                    Console.WriteLine($"The price for is: {PriceConstants.YouthPrice} ");
                    break;
                case AgeCategory.Adult:
                    Console.WriteLine($"The price for is: {PriceConstants.AdultPrice} ");
                    break;
                case AgeCategory.Senior:
                    Console.WriteLine($"The price for is: {PriceConstants.SeniorPrice} ");
                    break;
                case AgeCategory.Elder:
                    Console.WriteLine($"{PriceConstants.FreeEntry} ");
                    break;
            }
        }
        public static int GetNumberOfCustomers()                                // Menu choice: 2 Calculating customers group age and the cost for the whole group.
        {
            while (true)
            {
                Console.WriteLine("How many people will attend?");
                string? aInput = Console.ReadLine();
                if (int.TryParse(aInput, out int customerAmount) && customerAmount > 0)          // Parsing string to integer
                {
                    return customerAmount;                                                       // Returning the value
                }
                else ErrorMessage();                                                             // Error prompt to user 
                
            }
        }

        public static void GroupCalculation()                                   // Menu choice: 2 condensing the main menu
        {
            int customerCount = CustomerGroup();
            CustomerAges(customerCount);
            Console.WriteLine($"Amount of people: {customerCount}\n" +
                              $"Total Cost for the group: {CalculateTotalCost()}kr");
        }

        public static void CustomerMessage()                                    // Menu choice 3: Simple method of multiplying the message with a loop
        {
            Console.WriteLine("\nGive me your message");
            string? customerMessage = Console.ReadLine();                                                    // Receiving user message

            if (string.IsNullOrEmpty(customerMessage))
            {
                ErrorMessage();
            }

            for (int i = 0; i < 10; i++)                                                                     // Predefined loop logic that it has to do it 10 times
            {
                Console.Write(customerMessage + " ");
            }
        }
        public static bool CustomSplitter()                                     // Menu choice: 4 Method to fish out the third word in a sentence, programmed to avoid exceptions / spaces / tabs and similar
        {
            while (true)
            {
                Console.WriteLine("Please input your sentence with at least 3 words");
                string? customSplitter = Console.ReadLine();                                                // Reading off user input
                var words = Regex.Split(customSplitter ?? string.Empty, @"\s+");                            // Regex.Split is more advanced .Split form avoiding null exception with ??, avoiding tabs/multiple spaces. 
                                                                                                            // "@" makes string literal, escape sequences not processed. \s+ is for white spaces and line brakes to match inbetween incosistences
                if (words != null && words.Length >= 3)                                                     // Using logic that a sentence has to be at least 3 words long
                {
                    Console.WriteLine($"The third word in your sentence is: {words[2]}");                   // Displaying the third word in the sentence
                    return true;
                }
                else
                {
                    Console.WriteLine("Please write at least 3 word in the sentence. ");                    //loop automatically returns false
                }
            }
        }
        public static bool IsValidAge(int age)                                  // Wrong age check method
        {
            var ageCategory = GetAgeCategory(age);
            return ageCategory != AgeCategory.Invalid;                          // Using the enum to check if the Age Category is valid. Returning the ageCategory only if it fulfills predefined condition
        }
        public static int GetValidCustomerAge(int customerNumber)               // Checking the age of all of the customers in a group and adding them to respective age group
        {
            while(true)
            {
                Console.WriteLine($"Please input age of the customer: {customerNumber} ");
                string? aInput = Console.ReadLine();
                if (int.TryParse(aInput, out int age) && IsValidAge(age))       // Trying to parse the user input and checking with method if the age can be converted to respective age group
                {
                    return age;
                }
                else ErrorMessage();
            }
        }
        public static void IncrementalAgeCategoryCounters(int age)              // Creating a method for a clean switch case menu for ages that increase the Counters.
        {
            var ageCategory = GetAgeCategory(age);                              // Receiving the age categories from enum
            switch (ageCategory)                                                // Switch case menu counting up the customers in respect to their age
            {
                    case AgeCategory.Invalid:
                        Console.WriteLine("Invalid age provided.");
                        break;
                    case AgeCategory.Baby:
                        Counters.BabyCount++;
                        break;
                    case AgeCategory.Youth:
                        Counters.YouthCount++;
                        break;
                    case AgeCategory.Adult:
                        Counters.AdultCount++;
                        break;
                    case AgeCategory.Senior:
                        Counters.SeniorCount++;
                        break;
                    case AgeCategory.Elder:
                        Counters.ElderCount++;
                        break;
            }
        }
        public static int CustomerGroup()                                       // Helper method
        {
            return GetNumberOfCustomers();
        }

        public static void CustomerAges(int CustomerAmount)                     // Supporting method for the CustomerGroup, checking in which age category is predefined customer.
        {
            Counters.ResetCount();                                              // Making sure we're working with fresh set of data
            for (int i = 0; i < CustomerAmount; i++)                            // Loop that's going through the whole group
            {
                int age = GetValidCustomerAge(i + 1);
                ProcessCustomerAge(age);                 
            }
        }
        public static void ProcessCustomerAge(int age)                         // Helper method for the CustomerAges method
        {
            IncrementalAgeCategoryCounters(age);                               // Increasing the counter incrementally for respective age group
        }
        public static int CalculateTotalCost()                                 // Simple method calculation of available age groups.
        {
            return (Counters.YouthCount * 80) + (Counters.AdultCount * 120) + (Counters.SeniorCount * 90);
        }

    }
}
