using Elmah.Io.Client.Extensions.Correlation;
using Elmah.Io.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add Elmah.Io.Extensions.Logging
builder.Logging.AddElmahIo(options =>
{
    options.ApiKey = "API_KEY";
    options.LogId = new Guid("LOG_ID");
    // Enrich messages with correlation ID
    options.OnMessage = msg => msg.WithCorrelationIdFromActivity();
});

// Add Elmah.Io.AspNetCore
builder.Services.AddElmahIo(options =>
{
    options.ApiKey = "API_KEY";
    options.LogId = new Guid("LOG_ID");
    // Enrich messages with correlation ID
    options.OnMessage = msg => msg.WithCorrelationIdFromActivity();
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseElmahIo();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
