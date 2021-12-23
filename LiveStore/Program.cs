using Blazored.Toast;
using LiveStore.Data;
using LiveStore.Data.Interfaces;
using LiveStore.Data.Model;
using LiveStore.Middleware;
using LiveStore.ORM;
using LiveStore.ORM.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var dbPath = "myapp.db";

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();
builder.Services.AddDbContext<StoreContext>(
    options => options.UseSqlite($"Data Source = {dbPath}"));
// builder.Services.AddDbContext<StoreContext>(
//     options => options.UseNpgsql(
//         "Host=abul.db.elephantsql.com;Port=5432;Database=mzhvoivw;Username=mzhvoivw;Password=RVzHSil4Ly5yE-67ZVh_LfS2YwWoZjBd"));
builder.Services.AddScoped<ICatalog, InMemoryCatalog>();
builder.Services.AddSingleton<IClock, LocalDate>();
builder.Services.AddSingleton<IBasket, InMemoryBasket>();
builder.Services.AddScoped<ICategories, InMemoryCategories>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.Decorate<IProductRepository, LoggableProductRepository>();
builder.Services.AddSingleton<ObservableBasket>();
// builder.Host.UseSerilog(((context, configuration) => 
//     configuration.WriteTo.Sentry(o => 
//         o.Dsn = "https://0d93211647b5492383b86995e36585b7@o1093811.ingest.sentry.io/6113191")));
builder.Services.AddAntDesign();

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();
app.Use(async (context, next)=>
{
    var browser = context.Request.Headers["User-Agent"];
    if (!browser.ToString().Contains("Edg"))
    {
        await context.Response.WriteAsync(
            "This browser is not supported yet.");
        return; //прерываем выполнение конвейера
    }
    await next();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();