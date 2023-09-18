using Microsoft.Azure.Devices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExerciseLexicon2
{
    // Unused style of assignment
    //enum CustomerType 
    //{
    //    Youth, //0
    //    Adult, //1
    //    Senior //2
    //}

    internal class Utilities                                                    // Gathering of all variables and methods in one space
    {
        //public static int YouthCount = 0;                                       // Counter for repsective age group.
        //public static int AdultCount = 0;                                       // Counter for repsective age group.
        //public static int SeniorCount = 0;                                      // Counter for repsective age group.
        //public static int ElderCount = 0;                                       // Counter for repsective age group.
        //public static int BabyCount = 0;                                        // Counter for repsective age group.

        public static void AgeCheck(int age = 0)                                // AgeCheck method for case: 1 menu choice
        {
            Console.WriteLine("Please state your age");
            string? aInput = Console.ReadLine();                                // Reading user input 

            int.TryParse(aInput, out age);                                      // Converting user input into an integer value

            if (age < 20 && age > 5) Console.WriteLine("Youth Price: 80kr");                                 //using predefined logic in which age-category customer is
            else if (age > 100)      Console.WriteLine("Elders over 100 can enjoy our services for free. ");      //using predefined logic in which age-category customer is
            else if (age > 64)       Console.WriteLine("Senior Price: 90kr");                                     //using predefined logic in which age-category customer is
            else if (age < 5)        Console.WriteLine("Infants under the age of 5 come in free.");               //using predefined logic in which age-category customer is
            else                                                                                             //using predefined logic in which age-category customer is
            {
                Console.WriteLine("Standard Adult pricing: 120kr");
            }
            return;
        }
        public static int CustomerGroup(int CustomerAmount = 0, int TotalPrice = 0)                          // Calculating customers group age and the cost for the whole group.
        {
            Console.WriteLine("How many people will attend?");
            string? aInput = Console.ReadLine();
            if (int.TryParse(aInput, out CustomerAmount))                                                    // Parsing string to integer
            {
                return CustomerAmount;                                                                       // Returning the value
            }
            else
            {
                Console.WriteLine("Invalid input, no customers.");                                           // Making sure that there is amount of customers.
                return 0;
            }
        }
        public static AgeGroupCounters Counters = new AgeGroupCounters();                                    // Debug, if the menu is called multiple times to start with a fresh account
        public static void CustomerAges(int CustomerAmount, int age)                                         // Supporting method for the CustomerGroup, checking in which age category is predefined customer.
        {
            Counters.ResetCount();                                                                           // Making sure we're working with fresh set of data
            for (int i = 0; i < CustomerAmount; i++)                                                         // Loop that's going through the whole group
            {
                bool validInput = false;

                while (!validInput)
                {
                    Console.WriteLine("Please state age of the customer: " + (i + 1));              // Prompt to user to determine age of every each attendee
                    string? aInput = Console.ReadLine();                                                     // Reading off the user prompt

                    if (int.TryParse(aInput, out age))                                                       // Converting string to integer value
                    {
                        if (age >= 0)                                                                        // Checking for negative age
                        {
                            validInput = true;                                                                    // Using predefined logic to save the customer to a variable group
                        }
                        else
                        {
                            Console.WriteLine("Age can't be negative, try again. ");
                        }
                        if (age < 5) Counters.BabyCount++;                                                            // Using predefined logic to save the customer to a variable group
                        else if (age > 5 && age < 20) Counters.YouthCount++;                                          // Using predefined logic to save the customer to a variable group
                        else if (age >= 20 && age < 64) Counters.AdultCount++;                                        // Using predefined logic to save the customer to a variable group
                        else if (age > 64 && age < 100) Counters.SeniorCount++;                                       // Using predefined logic to save the customer to a variable group
                        else if (age > 100) Counters.ElderCount++;                                                    // Using predefined logic to save the customer to a variable group
                    }
                    else
                    {
                        Console.WriteLine("The age is incorrect, try again.");                               // Prompt to the user to write a proper age number
                    }
                }
            }
        }
        public static int CalculateTotalCost()                                                               // Simple method calculation of available age groups.
        {
            return (Counters.YouthCount * 80) + (Counters.AdultCount * 120) + (Counters.SeniorCount * 90);
            
        }
        public static void CustomerMessage()                                                                 // Simple method of multiplying the message with a loop
        {
            Console.WriteLine("\nGive me your message");
            string? customerMessage = Console.ReadLine();

            for (int i = 0; i < 10; i++)                                                                     // Predefined loop logic that it has to do it 10 times
            {
                Console.Write(customerMessage + " ");
            }

        }
        public static bool CustomSplitter()                                                                 // Method to fish out the third word in a sentence, programmed to avoid exceptions / spaces / tabs and similar
        {
            while (true)
            {
                Console.WriteLine("Please input your sentence with at least 3 words");
                string? customSplitter = Console.ReadLine();
                var words = Regex.Split(customSplitter ?? string.Empty, @"\s+");            // Regex.Split is more advanced .Split form avoiding null exception with ??, avoiding tabs/multiple spaces. 
                                                                                            // "@" makes string literal, escape sequences not processed. \s+ is for white spaces and line brakes to match inbetween incosistences
                if (words != null && words.Length >= 3)
                {
                    Console.WriteLine($"The third word in your sentence is: {words[2]}");
                    return true;
                }
                else
                {
                    Console.WriteLine("Please write at least 3 word in the sentence. ");    //loop automatically returns false
                }
            }
            
        }

    }
}
