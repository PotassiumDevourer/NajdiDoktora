﻿namespace NajdiDoktoraApp.Models
{
    public class CompleteClinic
    {
        public string Name { get; set; }
        public string FormattedAddress { get; set; }
        public string FormattedPhoneNumber { get; set; }
        public string Website { get; set; }
        public int ReviewCount { get; set; }
        public float AverageRating { get; set; }
        public double Distance { get; set; }
    }
}