//using Blazor_Server.Data;
//using Microsoft.Extensions.DependencyInjection;
//using Unity;
//using Unity.Microsoft.DependencyInjection; // This is needed for UnityServiceProviderFactory

//namespace Blazor_Server
//{
//    public class Unity_Framework
//    {
//        public static void Main(string[] args)
//        {
//            var serviceProvider = ConfigureServices();
//            // Other startup code
//        }

//        private static IServiceProvider ConfigureServices()
//        {
//            var container = new UnityContainer();

//            // Register services and dependencies
//            container.RegisterType<Interface, AudioData>();
//            container.RegisterType<DapperContext>();

//            // Create a ServiceProviderFactory based on UnityContainer
//            var serviceProviderFactory = new ServiceProviderFactory(container);

//            // Use the factory to create the service provider
//            return serviceProviderFactory.CreateServiceProvider(container);
//        }
//    }
//}
