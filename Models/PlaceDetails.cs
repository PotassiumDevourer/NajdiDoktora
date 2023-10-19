namespace NajdiDoktoraApp.Models
{

    public class Rootobject
    {
        public object[] html_attributions { get; set; }
        public DetailedResult DetailedResult { get; set; }
        public string status { get; set; }
    }

    public class DetailedResult
    {
        public Address_Components[] address_components { get; set; }
        public string adr_address { get; set; }
        public string business_status { get; set; }
        public Current_Opening_HoursDetail current_Opening_HoursDetail { get; set; }
        public string formatted_address { get; set; }
        public string formatted_phone_number { get; set; }
        public GeometryDetail GeometryDetail { get; set; }
        public string icon { get; set; }
        public string icon_background_color { get; set; }
        public string icon_mask_base_uri { get; set; }
        public string international_phone_number { get; set; }
        public string name { get; set; }
        public Opening_HoursDetail Opening_HoursDetail { get; set; }
        public Picture[] Pictures { get; set; }
        public string place_id { get; set; }
        public Code Code { get; set; }
        public float rating { get; set; }
        public string reference { get; set; }
        public Review[] reviews { get; set; }
        public string[] types { get; set; }
        public string url { get; set; }
        public int user_ratings_total { get; set; }
        public int utc_offset { get; set; }
        public string vicinity { get; set; }
        public string website { get; set; }
        public bool wheelchair_accessible_entrance { get; set; }
    }

    public class Current_Opening_HoursDetail
    {
        public bool open_now { get; set; }
        public Period[] periods { get; set; }
        public string[] weekday_text { get; set; }
    }

    public class Period
    {
        public Close close { get; set; }
        public Open open { get; set; }
    }

    public class Close
    {
        public string date { get; set; }
        public int day { get; set; }
        public string time { get; set; }
    }

    public class Open
    {
        public string date { get; set; }
        public int day { get; set; }
        public string time { get; set; }
    }

    public class GeometryDetail
    {
        public LocationDetail LocationDetail { get; set; }
        public ViewportDetail ViewportDetail { get; set; }
    }

    public class LocationDetail
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class ViewportDetail
    {
        public NortheastDetail NortheastDetail { get; set; }
        public SouthwestDetail SouthwestDetail { get; set; }
    }

    public class NortheastDetail
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class SouthwestDetail
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Opening_HoursDetail
    {
        public bool open_now { get; set; }
        public Period1[] periods { get; set; }
        public string[] weekday_text { get; set; }
    }

    public class Period1
    {
        public Close1 close { get; set; }
        public Open1 open { get; set; }
    }

    public class Close1
    {
        public int day { get; set; }
        public string time { get; set; }
    }

    public class Open1
    {
        public int day { get; set; }
        public string time { get; set; }
    }

    public class Code
    {
        public string compound_code { get; set; }
        public string global_code { get; set; }
    }

    public class Address_Components
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }

    public class Picture
    {
        public int height { get; set; }
        public string[] html_attributions { get; set; }
        public string Picture_reference { get; set; }
        public int width { get; set; }
    }

    public class Review
    {
        public string author_name { get; set; }
        public string author_url { get; set; }
        public string language { get; set; }
        public string original_language { get; set; }
        public string profile_Picture_url { get; set; }
        public int rating { get; set; }
        public string relative_time_description { get; set; }
        public string text { get; set; }
        public int time { get; set; }
        public bool translated { get; set; }
    }

}
