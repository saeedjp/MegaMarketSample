
using Mega.Application.Interface.Context;
using Mega.Application.Interfaces.FacadPatterns;
using Mega.Application.Services.Carts;
using Mega.Application.Services.Common.Queries.GetCategory;
using Mega.Application.Services.Common.Queries.GetHomePageImages;
using Mega.Application.Services.Common.Queries.GetMenuItem;
using Mega.Application.Services.Common.Queries.GetSlider;
using Mega.Application.Services.Fainances.Commands.AddRequestPay;
using Mega.Application.Services.Fainances.Queries.GetRequestPayForAdmin;
using Mega.Application.Services.Fainances.Queries.GetRequestPayService;
using Mega.Application.Services.HomePage.AddNewSlider;
using Mega.Application.Services.HomePages.AddHomePageImages;
using Mega.Application.Services.Orders.Commands.AddNewOrder;
using Mega.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Mega.Application.Services.Orders.Queries.GetUserOrders;
using Mega.Application.Services.Products.FacadPattern;
using Mega.Application.Services.Users.Command.SabteNam;
using Mega.Application.Services.Users.Commands.EditUser;
using Mega.Application.Services.Users.Commands.RemoveUser;
using Mega.Application.Services.Users.Commands.UserLogin;
using Mega.Application.Services.Users.Commands.UserSatusChange;
using Mega.Application.Services.Users.Queries.GetRoles;
using Mega.Application.Services.Users.Query.GetUser;
using Mega.Common.Roles;
using Mega.Persistance.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
  
namespace EndPoint.Site
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
            services.AddControllersWithViews();
            string contectionString = @"Data Source=.; Initial Catalog=Mega; Integrated Security=True;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(contectionString));

            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
                options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
                options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
            });
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/authentication/signin");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
                options.AccessDeniedPath = new PathString("/Authentication/Signin");

            });


            services.AddScoped<IContext, DataBaseContext>();
            services.AddScoped<IGetuserService, GetuserService>();
            services.AddScoped<IGetRolesService, GetRolesService>();
            services.AddScoped<ISabteNam, SabteNam>();
            services.AddScoped<IRemoveUserService, RemoveUserService>();
            services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
            services.AddScoped<IEditUserService, EditUserService>();

            services.AddScoped<IUserLoginService, UserLoginService>();

            //Facad
            services.AddScoped<IProductFacad, ProductFacad>();




            //---------------
            services.AddScoped<IGetMenuItemService, GetMenuItemService>();



            services.AddScoped<IAddNewSlider, AddNewSlider>();




            services.AddScoped<IGetCategoryService, GetCategoryService>();





            services.AddScoped<IGetSliderService, GetSliderService>();





            services.AddScoped<IAddHomePageImagesService, AddHomePageImagesService>();




            services.AddScoped<IGetHomePageImagesService, GetHomePageImagesService>();



            services.AddScoped<ICartServise, CartServise>();

            services.AddScoped<IAddRequestPayService, AddRequestPayService>();
            services.AddScoped<IGetRequestPayService, GetRequestPayService>();
            services.AddScoped<IAddNewOrderService, AddNewOrderService>();
            services.AddScoped<IGetUserOrdersService, GetUserOrdersService>();
            services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();
            services.AddScoped<IGetRequestPayForAdminService, GetRequestPayForAdminService>();



            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}" );
            });
        }
    }
}
