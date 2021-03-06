﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using SecurityPipeline.Pipeline;

[assembly: OwinStartup(typeof(SecurityPipeline.Startup))]

namespace SecurityPipeline
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            configuration.Routes.MapHttpRoute(
                "default",
                "api/{controller}");

            app.Use(typeof (TestMiddleware));

            app.UseWebApi(configuration);
        }
    }
}
