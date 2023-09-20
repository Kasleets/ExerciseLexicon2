using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLexicon2
{
    public class AgeGroupCounters
    {
        public int YouthCount { get; set; }  = 0;                                       // Counter for repsective age group.
        public int AdultCount { get; set; }  = 0;                                       // Counter for repsective age group.
        public int SeniorCount { get; set; } = 0;                                       // Counter for repsective age group.
        public int ElderCount { get; set; }  = 0;                                       // Counter for repsective age group.
        public int BabyCount { get; set; }   = 0;                                       // Counter for repsective age group.

        public static class PriceConstants                                              // Constant values, easier to manage if they're not hardcoded in strings.
        {
            public const int YouthPrice = 80;
            public const int AdultPrice = 120;
            public const int SeniorPrice = 90;
            public const string FreeEntry = "This age group receives free entry.";
        }
        public enum AgeCategory                                                         //Creating enum category instead of repeating them.
        {
            Invalid,
            Baby,
            Youth,
            Adult,
            Senior,
            Elder
        }
        public static AgeCategory GetAgeCategory(int age)                               // Using enum to refine the code according to DRY-s = Don't Repeat Yourself stupid.
        {                                                                               // Using enum to refine the code according to DRY-s = Don't Repeat Yourself stupid.
            if (age < 0) return AgeCategory.Invalid;                                    // Using enum to refine the code according to DRY-s = Don't Repeat Yourself stupid.
            if (age < 5) return AgeCategory.Baby;                                       // Using enum to refine the code according to DRY-s = Don't Repeat Yourself stupid.
            if (age < 20) return AgeCategory.Youth;                                     // Using enum to refine the code according to DRY-s = Don't Repeat Yourself stupid.
            if (age < 64) return AgeCategory.Adult;                                     // Using enum to refine the code according to DRY-s = Don't Repeat Yourself stupid.
            if (age < 100) return AgeCategory.Senior;                                   // Using enum to refine the code according to DRY-s = Don't Repeat Yourself stupid.
            return AgeCategory.Elder;                                                   // Using enum to refine the code according to DRY-s = Don't Repeat Yourself stupid.
        }
        public void ResetCount()                                                        // Reset of the values to avoid a bug of double group while prompting menu couple times
        {
            YouthCount  = 0;
            AdultCount  = 0;
            SeniorCount = 0;
            ElderCount  = 0;
            BabyCount   = 0;
        }
        public static void ErrorMessage()                                               // Regular Error Message for use in different places
        {
            Console.WriteLine("Invalid input, please try again. ");
        }

        public static void ProgramExit()                                                // Method for quitting the program successfully
        {
            Console.WriteLine("Closing the application down, thank you.");                    
            Environment.Exit(0);
        }
    }
}

