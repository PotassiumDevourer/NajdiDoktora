using NajdiDoktoraApp.Enums;

namespace NajdiDoktoraApp.StaticData
{
    public static class EnumMapper
    {
        public static EnumMapEntry[] ClinicTypeMap { get; set; } =
        {
            new EnumMapEntry(ClinicType.Dentist, "Zubní lékaři", @"https://services6.arcgis.com/ogJAiK65nXL1mXAW/arcgis/rest/services/Zubní_lékaři/FeatureServer/0/query?where=1%3D1&outFields=*&outSR=4326&f=json"),
            new EnumMapEntry(ClinicType.GeneralPracticioner, "Praktičtí lékaři pro dospělé", @"https://services6.arcgis.com/ogJAiK65nXL1mXAW/arcgis/rest/services/Praktičtí_lékaři_pro_dospělé/FeatureServer/0/query?where=1%3D1&outFields=*&outSR=4326&f=json"),
            new EnumMapEntry(ClinicType.ChildGeneralPracticioner, "Praktičtí lékaři pro děti a dorost", @"https://services6.arcgis.com/ogJAiK65nXL1mXAW/arcgis/rest/services/Praktičtí_lékaři_pro_děti_a_dorost/FeatureServer/0/query?where=1%3D1&outFields=*&outSR=4326&f=json"),
            new EnumMapEntry(ClinicType.Emergency, "Lékařská pohotovostní služba", @"https://services6.arcgis.com/ogJAiK65nXL1mXAW/arcgis/rest/services/Lékařská_pohotovostní_služba/FeatureServer/0/query?where=1%3D1&outFields=*&outSR=4326&f=json"),
            new EnumMapEntry(ClinicType.Aftercare, "Následná péče", @"https://services6.arcgis.com/ogJAiK65nXL1mXAW/arcgis/rest/services/Následná_péče/FeatureServer/0/query?where=1%3D1&outFields=*&outSR=4326&f=json"),
            new EnumMapEntry(ClinicType.Gynecologist, "Ambulatní gynekologové", @"https://services6.arcgis.com/ogJAiK65nXL1mXAW/arcgis/rest/services/Ambulantní_gynekologové/FeatureServer/0/query?where=1%3D1&outFields=*&outSR=4326&f=json")
        };
    }
}
