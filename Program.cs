using CalculatorForInterviewPrep.Services;
using CalculatorForInterviewPrep.Repositories;
using CalculatorForInterviewPrep.Models.Services;
using CalculatorForInterviewPrep.Models.Operations;

var builder = WebApplication.CreateBuilder(args);

// Register services with DI container
builder.Services.AddSingleton<ICalculationRepository, CalculationRepository>();
builder.Services.AddSingleton<ICalculatorService,CalculatorService>();
builder.Services.AddSingleton<IFilteredResultsDisplayService, FilteredResultsDisplayService>();
builder.Services.AddSingleton<IOperationFactory, OperationFactory>();

// Add controllers with views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Calculator/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map default route for controller actions
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculator}/{action=Index}/{id?}");

app.Run();
