using Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire;
using Hangfire.SqlServer;

[assembly: OwinStartupAttribute(typeof(web.Startup))]
namespace web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(
                "HangFireDb",
                new SqlServerStorageOptions
                {
                    // set to true to have HangFire create your schema
                    PrepareSchemaIfNecessary = true,
                    // set to false and run HangFire.sql to create your sql.
                    //PrepareSchemaIfNecessary = false, 
                    QueuePollInterval = TimeSpan.FromSeconds(1)
                });

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}