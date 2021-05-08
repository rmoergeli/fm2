using fm2.Client.Models;
using fm2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fm2.Client.ViewModels
{
    public interface IFetchDataViewModel
    {
        WeatherForecast[] WeatherForecasts { get; set; }
        Task RetrieveForecastsAsync();
        Task OnInitializedAsync();
    }
    public class FetchDataViewModel : IFetchDataViewModel
    {
        private WeatherForecast[] _weatherForecasts;
        private IFetchDataModel _fetchDataModel;
        public WeatherForecast[] WeatherForecasts
        {
            get => _weatherForecasts;
            set => _weatherForecasts = value;
        }
        public FetchDataViewModel(IFetchDataModel fetchDataModel)
        {
            Console.WriteLine("FetchDataViewModel Constructor Executing");
            _fetchDataModel = fetchDataModel;
        }

        public async Task RetrieveForecastsAsync()
        {
            _weatherForecasts = await _fetchDataModel.RetrieveForecastsAsync();
            Console.WriteLine("FetchDataViewModel Forecasts Retrieved");
        }

        public async Task OnInitializedAsync()
        {
            _weatherForecasts = await _fetchDataModel.RetrieveForecastsAsync();
        }
    }
}
