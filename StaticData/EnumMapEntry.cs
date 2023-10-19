using NajdiDoktoraApp.Enums;

namespace NajdiDoktoraApp.StaticData
{
    public class EnumMapEntry
    {
        public ClinicType Type { get; set; }
        public string ClinicName { get; set; }
        public string Endpoint { get; set; }

        public EnumMapEntry(ClinicType type, string clinicName, string endpoint)
        {
            Type = type;
            ClinicName = clinicName;
            Endpoint = endpoint;

        }
    }
}
