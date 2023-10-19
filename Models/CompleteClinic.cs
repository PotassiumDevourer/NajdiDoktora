namespace NajdiDoktoraApp.Models
{
    public class CompleteClinic
    {
        public string Name { get; set; }
        public string PlaceId { get; set; }
        public string FormattedAddress { get; set; }
        public string FormattedPhoneNumber { get; set; }
        public string Website { get; set; }
        public int ReviewCount { get; set; }
        public string Status { get; set; }
        public string EmbedLink { get; set; }
        public float AverageRating { get; set; }
        public double Distance { get; set; }
        public bool IsOpen { get; set; }
        public Review[] Reviews { get; set; }
    }
}
