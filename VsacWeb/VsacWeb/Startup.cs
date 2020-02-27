using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using VsacWeb.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VsacWeb.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using AspNetCore.RouteAnalyzer; // Add
using System.Security.Claims;
using VsacWeb.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using VsacWeb.Areas.Identity.Pages.Account;

namespace VsacWeb
{

    public class AuthorizedAction : Controller, IActionFilter
    {
        //  private Controllers.UsuarioUrlsController _usuarioUrlsController;
        //public AuthorizedAction(Controllers.UsuarioUrlsController usuarioUrlsController)
        //{
        //    _usuarioUrlsController = usuarioUrlsController;
        //}

        public ApplicationDbContext _context;


        public AuthorizedAction(ApplicationDbContext context)
        {
            _context = context;
        }
       

        //public override void OnResultExecuting(ResultExecutingContext filterContext)
        //{

        //}

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

          


            if (filterContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier) == null)
            {
                filterContext.Result = new RedirectResult("~/Identity/Account/Login");
                //filterContext.Result = new RedirectToRouteResult(
                //    new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
                return;
            }

            //var user = new UsuarioUrlsController(filterContext.Controller);


            //var listUrlsUser = _usuarioUrlsController.GetUrlsUser(
            //    filterContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).ToString());

            char[] cara = new char[10];

            cara[0] = ' ';
            cara[1] = ':';

            var separador = filterContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).ToString()
                .Split(cara);


            var listUrlsUser = _context.UsuarioUrls.Where(x => x.AppUserId.Equals(separador[separador.Count()-1]));

          //  var  = _context.UsuarioUrls.ToList();

           // var menus = JsonConvert.DeserializeObject<List<UsuarioUrls>>
             //   ( filterContext.HttpContext.Session.GetString("menus"));
          
            
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            string url = "/" + controllerName + "/" + actionName;
           
            if (listUrlsUser.Where(s => s.Url.Caminho == url).Any())
            {

                filterContext.Result = new RedirectResult("~/Identity/Account/AccessDenied");
                // RedirectToPageResult("AccessDenied");
                //  filterContext.Result = new   RedirectToRouteResult(
                //    new RouteValueDictionary { { "controller", "Identity" },  { "action", "Account/Login" } });
                return;
            }
        }

    }
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ConnectionOne")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

          //  services.AddDbContext<DataContext>(options => options.UseSqlServer
            //  (Configuration.GetConnectionString("ConnectionOne")));

            //services.AddIdentityCore<AppUser>().AddRoles<AppRole>()
            //    .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<AppUser, AppRole>>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders()
            //    .AddDefaultUI();

            services.AddIdentityCore<AppUser>()
              .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<AppUser>>()
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders()
              .AddDefaultUI();


            
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();


            services.AddTransient<Controllers.UsuarioUrlsController, Controllers.UsuarioUrlsController>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

          
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });


           
           
        }
    }
}
