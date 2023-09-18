﻿using System;
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
        public int SeniorCount { get; set; } = 0;                                      // Counter for repsective age group.
        public int ElderCount { get; set; }  = 0;                                       // Counter for repsective age group.
        public int BabyCount { get; set; }   = 0;

        public void ResetCount()
        {
            YouthCount  = 0;
            AdultCount  = 0;
            SeniorCount = 0;
            ElderCount  = 0;
            BabyCount   = 0;
        }
        public static class PriceConstants
        {
            public const int YouthPrice = 80;
            public const int AdultPrice = 120;
            public const int SeniorPrice = 90;
            public const string FreeEntry = "This age group receives free entry.";
        }
       
    }


}
