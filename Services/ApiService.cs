using NajdiDoktoraApp.Enums;
using NajdiDoktoraApp.Models;
using NajdiDoktoraApp.StaticData;

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
                    double latDiff = (double)Math.Abs(item.attributes.y - searchData.UserLat);
                    double longDiff = (double)Math.Abs(item.attributes.x - searchData.UserLong);
                    item.Distance = Math.Sqrt(Math.Pow(latDiff, 2) + Math.Pow(longDiff, 2));
                }
                clinicData.features = clinicData.features.OrderBy(x => x.Distance).ToArray();
            }
            for (int i = 0; i < searchData.ResultCount; i++)
            {
                var item = clinicData.features[i];
                result.Add(new CompleteClinic()
                {
                    Website = item.attributes.www,
                    Distance = item.Distance,
                }) ;
            }

            return result.ToArray();
        }
    }
}