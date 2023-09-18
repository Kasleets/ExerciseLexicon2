using Microsoft.Azure.Devices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLexicon2
{
    enum CustomerType
    {
        Youth, //0
        Adult, //1
        Senior //2
    }

    internal class Utilities
    {
        public static int YouthCount = 0;
        public static int AdultCount = 0;
        public static int SeniorCount = 0;
        //AgeCheck customerList = new CustomerList();
        public static void AgeCheck(int age = 0)
        {
            Console.WriteLine("Please state your age");
            string? aInput = Console.ReadLine();

            int.TryParse(aInput, out age);

            if (age < 20) Console.WriteLine("Youth Price: 80kr");

            else if (age > 64) Console.WriteLine("Senior Price: 90kr");

            else
            {
                Console.WriteLine("Standard pricing: 120kr");

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
                        if (age < 20) YouthCount++;
                        else if (age > 64) SeniorCount++;
                        else AdultCount++;
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
    }
}
