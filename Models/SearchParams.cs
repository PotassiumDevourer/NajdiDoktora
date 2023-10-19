using NajdiDoktoraApp.Enums;

namespace NajdiDoktoraApp.Models
{
    public class SearchParams
    {
        public double UserLong { get; set; }
        public double UserLat { get; set; }
        public ClinicType Type { get; set; }
        public int ResultCount { get; set; }
    }
}
