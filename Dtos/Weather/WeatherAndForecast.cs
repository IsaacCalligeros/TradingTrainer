namespace Youkozi.Dtos
{
    public class WeatherAndForecast
    {
        public WeatherAndForecast(CurrentWeather currentWeather, Weather weather)
        {
            CurrentWeather = currentWeather;
            Weather = weather;
        }
        public CurrentWeather CurrentWeather { get; set; }
        public Weather Weather { get; set; }
    }
}