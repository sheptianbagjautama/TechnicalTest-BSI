using Microsoft.EntityFrameworkCore;
using TechnicalTest_BSI_Soal3.Data;
using TechnicalTest_BSI_Soal3.Repositories.Interfaces;
using TechnicalTest_BSI_Soal3.Repositories.TransactionRepository;
using TechnicalTest_BSI_Soal3.Services.Interfaces;
using TechnicalTest_BSI_Soal3.Services.TransactionService;

var builder = WebApplication.CreateBuilder(args);

// Tambahkan DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
