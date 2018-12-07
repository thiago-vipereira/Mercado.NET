using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mercado.NET.Web.Ui.Data;
using Mercado.NET.Web.Ui.Models;
using Mercado.NET.Web.Ui.Services;

namespace Mercado.NET.Web.Ui
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IProdutoService, ProdutoService>();
            //services.AddScoped<IProdutoPreco, ProdutoPrecoService>();
            services.AddScoped<IComprasService, ComprasService>();
            //services.AddScoped<ICompraItens, CompraItenService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<ApplicationUser> userManager,
                      RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                EnsureRoleAsync(roleManager).Wait();
                EnsureTestAdminAsync(userManager).Wait();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static async Task EnsureRoleAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager.RoleExistsAsync("Administrator");

            if (alreadyExists)
                return;

            await roleManager.CreateAsync(new IdentityRole("Administrator"));

        }

        private static async Task EnsureTestAdminAsync(UserManager<ApplicationUser> userManager)
        {
            var testAdmin = await userManager.Users
                .Where(x => x.UserName == "admin@teste.com")
                .SingleOrDefaultAsync();

            if (testAdmin != null)
            {
                await userManager.AddToRoleAsync(testAdmin, "Administrator");
                return;
            }
                

            testAdmin = new ApplicationUser
            {
                UserName = "admin@teste.com",
                Email = "admin@teste.com"
            };

            await userManager.CreateAsync(testAdmin, "Admin!123");

            await userManager.AddToRoleAsync(testAdmin, "Administrator");
        }
    }
}
