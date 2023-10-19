using NajdiDoktoraApp.Enums;
using NajdiDoktoraApp.Models;
using NajdiDoktoraApp.StaticData;
using System.Runtime.ExceptionServices;

namespace NajdiDoktoraApp.Services
{
    public class ApiService
    {
        private HttpClient _client { get; set; }
        private string _apiKey { get; set; }

        public ApiService(string apiKey)
        {
            _client = new HttpClient();
            _apiKey = apiKey;

        }
        public async Task<CompleteClinic[]> GetClinics(SearchParams searchData)
        {
            List<CompleteClinic> result = new List<CompleteClinic>();
            string endpoint = EnumMapper.ClinicTypeMap.First(x => x.Type == searchData.Type).Endpoint;
            var clinicData = await _client.GetFromJsonAsync<ClinicData>(endpoint);
            if(clinicData != null )
            {
                foreach (var item in clinicData.features)
                {
                    double latDiff = (double)Math.Abs(item.attributes.y - searchData.UserLat) * 111;
                    double longDiff = (double)Math.Abs(item.attributes.x - searchData.UserLong) * 111.321;
                    item.Distance = Math.Sqrt(Math.Pow(latDiff, 2) + Math.Pow(longDiff, 2));
                }
                clinicData.features = clinicData.features.OrderBy(x => x.Distance).ToArray();
            }
            int dataCount = searchData.ResultCount;
            for (int i = 0; i < dataCount; i++)
            {

                var item = clinicData.features[i];
                if (item.attributes.www == null)
                    continue;
                var completeData = new CompleteClinic();
                var searchResult = await _client.GetFromJsonAsync<PlaceSearchResults>(@$"https://maps.googleapis.com/maps/api/place/textsearch/json?query={item.attributes.www}&key={_apiKey}");
                if (searchResult != null)
                {
                    var bestMatch = searchResult.results.FirstOrDefault(x => x.types.Contains("hospital") || x.types.Contains("health") || x.types.Contains("doctor") || x.types.Contains("dentist") || (x.types.Contains("street_address") && x.types.Count() == 1));
                    if(bestMatch == null)
                    {
                        dataCount++;
                        continue;
                    }
                        
                    completeData.FormattedAddress = bestMatch.formatted_address;
                    completeData.Name = bestMatch.name;
                    completeData.ReviewCount = bestMatch.user_ratings_total;
                    completeData.AverageRating = bestMatch.rating;
                    completeData.Status = bestMatch.business_status;
                    completeData.EmbedLink = @$"https://www.google.com/maps/embed/v1/place?key=AIzaSyCQc83GzJ7_-CgWmE6qlrzb8_so_rnQ0rs&q=place_id:{bestMatch.place_id}";
                    var url = @$"https://maps.googleapis.com/maps/api/place/details/json?place_id={bestMatch.place_id}&key={_apiKey}";
                    var detail = await _client.GetFromJsonAsync<PlaceDetails>(url);
                    if(detail != null)
                    {
                        completeData.FormattedPhoneNumber = detail.result.formatted_phone_number;
                    }
                    
                }

                if (dataCount >= 40)
                {
                    break;
                }
                completeData.Website = item.attributes.www;
                completeData.Distance = item.Distance;
                result.Add(completeData);
            }

            return result.ToArray();
        }
    }
}