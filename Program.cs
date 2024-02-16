var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Test
// Create an instance of HttpClientHandler
var handler = new HttpClientHandler();

// Configure the handler to ignore SSL certificate errors
handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
{
    // Return true to allow untrusted certificates
    return true;
};

// Pass the handler to HttpClient
var client = new HttpClient(handler);
//
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Catalogue}/{action=Index}/{id?}");

app.Run();
