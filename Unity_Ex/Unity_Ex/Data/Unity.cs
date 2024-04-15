using Unity;

namespace Unity_Ex.Data
{
    public class Unity
    {
        static void Main(string[] args)
        {
            UnityContainer IU = new UnityContainer();
            /* Register a type*/
            IU.RegisterType<WeatherForecast>();
            IU.RegisterType<WeatherForecastService>();
            /* Register a type with specific members to be injected. */
            IU.RegisterType<IWeatherForecastService, WeatherForecastService>();
            WeatherForecastService objDL = IU.Resolve<WeatherForecastService>(); 
            objDL.GetForecastAsync(DateTime.Now);
        }





    }
}
