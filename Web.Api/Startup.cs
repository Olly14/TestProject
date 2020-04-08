using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Api.Data.Infrastructure.Persistence;
using Web.Api.Data.Infrastructure.Persistence.AppUsersRepo;
using Web.Api.Data.Infrastructure.Persistence.DropDownListsRepository;
using Web.Api.Data.Infrastructure.Persistence.OrderItemsRepo;
using Web.Api.Data.Infrastructure.Persistence.OrdersRepo;
using Web.Api.Data.Infrastructure.Persistence.ProductsRepo;
using Web.Api.Data.Infrastructure.Repository;
using Web.Api.Data.Infrastructure.Repository.IDropDownListsRepository;
using Web.Api.Data.Infrastructure.Repository.IOrderItemsRepository;
using Web.Api.Data.Infrastructure.Repository.IOrdersRepository;
using Web.Api.Data.Infrastructure.Repository.IProductRepository;
using Web.Api.Data.Infrastructure.Repository.IAppUsersRepositiry;
using Web.Api.Domain;
using AutoMapper;
using Web.Api.ModelMappers.OrderMappers;
using Web.Api.ModelMappers.AppUserMappers;
using Web.Api.ModelMappers.ProductMappers;
using Web.Api.ModelMappers.DropDownListsMappers;
using Web.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Web.Api
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
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IUnitOfWork<AppUser>, UnitOfWorkAppUserRepo>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork<Product>, UnitOfWorkProductRepo>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemsRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OrderDtoAutoMapperProfile());
                mc.AddProfile(new AppUserDtoAutoMapperProfile());
                mc.AddProfile(new ProductDtoAutoMapperProfile());
                mc.AddProfile(new DropDownListsDtoAutoMapperProfile());

            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddDbContext<BdContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BdConnectionString"), b => b.MigrationsAssembly("Web.Api"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes => {

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
