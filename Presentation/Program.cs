using Business;
using _Data;
using _Data.Repository;
using Business.Service;
using Business.Service.Interfaces;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

namespace Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<CoffeeShopContext>(opts => 
          opts.UseSqlServer("Server=EASV-DB4.easv.dk;Database=CoffeeShopAPIEksamenMP;User Id=CSe2022t_t_6;Password=CSe2022tT6#;TrustServerCertificate=True;"));
        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddLogging();
        builder.Services.AddCors();
        
        // Services
        builder.Services.AddScoped<IAddressService, AddressService>();
        builder.Services.AddScoped<ICakeService, CakeService>();
        builder.Services.AddScoped<ICoffeePlaceService, CoffeePlaceService>();
        builder.Services.AddScoped<ICoffeeService, CoffeeService>();
        builder.Services.AddScoped<IIngredientService, IngredientService>();
        builder.Services.AddScoped<IMembershipService, MembershipService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IPostService, PostService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IUserService, UserService>();
        
        //Repositories
        builder.Services.AddScoped<IAddressRepository, AddressRepository>();
        builder.Services.AddScoped<ICakeRepository, CakeRepository>();
        builder.Services.AddScoped<ICoffeePlaceRepository, CoffeePlaceRepository>();
        builder.Services.AddScoped<ICoffeeRepository, CoffeeRepository>();
        builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
        builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IPostRepository, PostRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddControllers();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
        
        app.UseRouting();
        //app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}