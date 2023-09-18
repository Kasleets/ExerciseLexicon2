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

    internal class Utilities
    {
        public static int YouthCount = 0;
        public static int AdultCount = 0;
        public static int SeniorCount = 0;
        public static int ElderCount = 0;
        public static int BabyCount = 0;
        public static void AgeCheck(int age = 0)
        {
            Console.WriteLine("Please state your age");
            string? aInput = Console.ReadLine();

            int.TryParse(aInput, out age);

            if (age < 20 && age > 5) Console.WriteLine("Youth Price: 80kr");
            else if (age > 100) Console.WriteLine("Elders over 100 can enjoy our services for free. ");
            else if (age > 64)  Console.WriteLine("Senior Price: 90kr");
            else if (age < 5)   Console.WriteLine("Infants under the age of 5 come in free.");
            else
            {
                Console.WriteLine("Standard Adult pricing: 120kr");
            }
            return;
        }
        public static int CustomerGroup(int CustomerAmount = 0, int TotalPrice = 0)
        {
            Console.WriteLine("How many people will attend?");
            string? aInput = Console.ReadLine();
            if (int.TryParse(aInput, out CustomerAmount))
            {
                return CustomerAmount;
            }
            else
            {
                Console.WriteLine("Invalid input, no customers.");
                return 0;
            }
        }
        public static void CustomerAges(int CustomerAmount, int age)
        {
            for (int i = 0; i < CustomerAmount; i++)
            {
                bool validInput = false;

                while (!validInput)
                {
                    Console.WriteLine("Please state your age for customer number: " + (i + 1));
                    string? aInput = Console.ReadLine();

                    if (int.TryParse(aInput, out age))
                    {
                        validInput = true;
                        if (age < 5) BabyCount++;
                        else if (age > 5 && age < 20) YouthCount++;
                        else if (age >= 20 && age < 64) AdultCount++;
                        else if (age > 64 && age < 100) SeniorCount++;
                        else if (age > 100) ElderCount++;
                        
                    }
                    else
                    {
                        Console.WriteLine("The age is incorrect, try again.");
                    }
                }
            }
        }
        public static int CalculateTotalCost()
        {
            return (YouthCount * 80) + (AdultCount * 120) + (SeniorCount * 90);
            
        }
        public static void CustomerMessage()
        {
            Console.WriteLine("\nGive me your message");
            string? customerMessage = Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                Console.Write(customerMessage + " ");
            }

        }
        public static bool CustomSplitter()
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
