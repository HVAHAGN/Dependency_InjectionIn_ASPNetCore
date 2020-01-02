using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TennisBookings.Web.Configuration;
using TennisBookings.Web.Services;
using TennisBookings.Web.ViewModels;

namespace TennisBookings.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherForecaster _weatherForcaster;
        private readonly FeaturesConfiguration _options;

        public HomeController(IWeatherForecaster weatherForcaster, IOptions<FeaturesConfiguration>options)
        {
            _weatherForcaster = weatherForcaster;
            _options = options.Value;
        }


        [Route("")]
        public IActionResult Index()
        {
            var viewModel = new HomeViewModel();

            
            var currentWeather = _weatherForcaster.GetCurrentWeather();
            
            switch (currentWeather.WeatherCondition)
            {
                case WeatherCondition.Sun:
                    viewModel.WeatherDescription = "It's sunny right now. " +
                                                   "A great day for tennis.";
                    break;
                case WeatherCondition.Rain:
                    viewModel.WeatherDescription = "We're sorry but it's raining " +
                                                   "here. No outdoor courts in use.";
                    break;
                default:
                    viewModel.WeatherDescription = "We don't have the latest weather " +
                                                   "information right now, please check again later.";
                    break;
            }

            return View(viewModel);
        }
    }
}