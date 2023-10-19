namespace NajdiDoktoraApp.Models
{

    public class ClinicData
    {
        public string objectIdFieldName { get; set; }
        public Uniqueidfield uniqueIdField { get; set; }
        public string globalIdFieldName { get; set; }
        public string geometryType { get; set; }
        public Spatialreference spatialReference { get; set; }
        public Field[] fields { get; set; }
        public Clinic[] features { get; set; }
    }

    public class Uniqueidfield
    {
        public string name { get; set; }
        public bool isSystemMaintained { get; set; }
    }

    public class Spatialreference
    {
        public int wkid { get; set; }
        public int latestWkid { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public string alias { get; set; }
        public string sqlType { get; set; }
        public int length { get; set; }
        public object domain { get; set; }
        public object defaultValue { get; set; }
    }

    public class Clinic
    {
        public Attributes attributes { get; set; }
        public Geometry geometry { get; set; }
        public double Distance { get; set; }
    }

    public class Attributes
    {
        public string provozovatel { get; set; }
        public string ico { get; set; }
        public string pravni_forma { get; set; }
        public string nazev_oboru { get; set; }
        public string nazev_vusc { get; set; }
        public string kod_vusc { get; set; }
        public string nazev_okresu { get; set; }
        public string kod_okresu { get; set; }
        public string nazev_orp { get; set; }
        public string kod_orp { get; set; }
        public string nazev_obce { get; set; }
        public string kod_obce { get; set; }
        public string nazev_ulice { get; set; }
        public string cislo_domovni { get; set; }
        public string typ_cisla_domovniho { get; set; }
        public string cislo_orientacni { get; set; }
        public string psc { get; set; }
        public string www { get; set; }
        public string wkt { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public string dp_id { get; set; }
        public int OBJECTID { get; set; }
    }

    public class Geometry
    {
        public float x { get; set; }
        public float y { get; set; }
    }

}
