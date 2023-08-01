using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication1.Core.Repositories;
using WebApplication1.Core.Repositories.Interfaces;
using WebApplication1.Data.Contexts;
using WebApplication1.Data.Repositories;
using WebApplication1.Service.Profiles.Categories;
using WebApplication1.Service.Profiles.Products;
using WebApplication1.Service.Services.Implementations;
using WebApplication1.Service.Services.Interfaces;
using WebApplication1.Service.Validations.Categories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApiDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 8;

}).AddDefaultTokenProviders().AddEntityFrameworkStores<ApiDbContext>();

builder.Services.AddCors(o => o.AddPolicy("Danziyev", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddControllers().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<CategoryPostDtoValidation>()).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
}); ;
builder.Services.AddAutoMapper(typeof(CategoryProfile));

builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IIdentityService,IdentityService>();
builder.Services.AddHttpContextAccessor();



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

app.UseCors("Danziyev");

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
