using QuartzSampleMVC.App_Start;
using QuartzSampleMVC.Service;
using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace QuartzSampleMVC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            ServiceContainer.Current.RegisterType<IDataService, DataService>();
            //½«ÈÝÆ÷×¢²áµ½mvcÖÐ
            DependencyResolver.SetResolver(new UnityDependencyResolver(ServiceContainer.Current));
        }
    }
}