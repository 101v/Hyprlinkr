﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http.Dispatcher;
using Newtonsoft.Json.Serialization;

namespace Ploeh.Samples.Hyprlinkr.ExampleService
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new
                {
                    controller = "Home",
                    id = RouteParameter.Optional
                }
            );

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new MyCustomControllerActivator());

            GlobalConfiguration
                .Configuration
                .Formatters
                .JsonFormatter
                .SerializerSettings
                .ContractResolver = new CamelCasePropertyNamesContractResolver();
            GlobalConfiguration
                .Configuration
                .Formatters
                .XmlFormatter
                .UseXmlSerializer = true;
        }
    }
}