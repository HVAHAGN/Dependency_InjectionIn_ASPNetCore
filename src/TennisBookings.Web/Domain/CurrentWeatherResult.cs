

using TennisBookings.Web.Services;

namespace TennisBookings.Web.Domain
{
    public class CurrentWeatherResult
    {
        public string Description { get; set; }
        public WeatherCondition WeatherCondition { get; set; }
    }
}
