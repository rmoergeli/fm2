using fm2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace fm2.Client.Models
{
    public interface IFetchDataModel
    {
        Task<WeatherForecast[]> RetrieveForecastsAsync();
    }
    public class FetchDataModel : IFetchDataModel
    {
        private HttpClient _http;
        public FetchDataModel(HttpClient http)
        {
            _http = http;
        }
        public async Task<WeatherForecast[]> RetrieveForecastsAsync()
        {
            return await _http.GetFromJsonAsync<WeatherForecast[]>("api/SampleData/WeatherForecasts");
        }
    }
}
