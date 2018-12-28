using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCDemo.DataAccess;
using MVCDemo.Repositories;

namespace MVCDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // here we provide "services" to be injected to classes that require them at runtime.

            // this says, when anyone needs a IMovieRepo, construct a MovieRepoDB for them.
            // ("scoped" has to do with the object's lifetime)
            services.AddScoped<IMovieRepo, MovieRepoDB>();

            // three lifetimes for a service
            // "scoped" means, one instance of this obejct will be shared to all who need it
            // within the span of this request
            // "transient' (AddTransient" means, a new instance of the object every time, for every 
            // new object who wants one.
            // "singleton" (AddSingleton) means, only one instance ever, across however many request. 


            // this says, when anyone wants the dbcontext MovieDBContext, get him one,
            // using SQL Server and a connection string found in appsettings.json (Configuration).
            services.AddDbContext<MovieDBContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MVCDemo")));

            // dbcontexts are added with "scoped" lifetine by default.

            // lifetimes should make sense
            // .e.g.g if my repo needs a dbcontext, and the dbcontext is scoped.
            // then my repo shold be either scroped or transient

            // if you get an exception saying "no service could be found for__"
            // this means you probably forgot to add a service here 

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // here in Startup.Configure is our global convention routing

            app.UseMvc(routes =>
            {
                // 

                routes.MapRoute(
                  name: "cast",
                  template: "Actors/{name}",
                  defaults: new { controller = "cast", action = "Index"});
                // this following route was generated automatically

                // this is one route.
                // there's the base URL (in our case, something like https://localhost:112345/


                //this route says, everythin before the first slash will be understood
                // as the name of the controller (built-in "controller" variable)

                // everything efore the next slash will be understood as the anme of the acction method
                // (built-in "action" variable)

                // everything after the slash will be put into a route parameter called "id"


                // every route needs to set controller and action in some way
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // if there's no id, that's fine, it's marked as optinal with the ?
                // if there's no actions, it defaults to "Index"
                // if there's no controller, it defaults to "Home"
            });
        }
    }
}
