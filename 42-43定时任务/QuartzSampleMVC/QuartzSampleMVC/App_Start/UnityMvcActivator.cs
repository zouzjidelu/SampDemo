using QuartzSampleMVC.App_Start;
using System.Linq;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(QuartzSampleMVC.UnityMvcActivator), nameof(QuartzSampleMVC.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(QuartzSampleMVC.UnityMvcActivator), nameof(QuartzSampleMVC.UnityMvcActivator.Shutdown))]

namespace QuartzSampleMVC
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with ASP.NET MVC.
    /// </summary>
    public static class UnityMvcActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start()
        {
            //FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            //FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.Container));

            //DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));
            UnityConfig.RegisterComponents();
            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            ServiceContainer.Current.Dispose();
        }
    }
}