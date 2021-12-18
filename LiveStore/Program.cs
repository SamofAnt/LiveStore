using Blazored.Toast;
using LiveStore.Data;
using LiveStore.Data.Interfaces;
using LiveStore.Data.Model;
using LiveStore.ORM;
using LiveStore.ORM.Repositories;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddSingleton<ObservableBasket>();
builder.Services.AddAntDesign();

var app = builder.Build();

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