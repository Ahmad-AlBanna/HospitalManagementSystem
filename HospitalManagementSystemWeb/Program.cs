using HospitalManagementSystemWeb.Services;
using HospitalManagementSystemWeb.Services.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress =
    new Uri("https://localhost:7000/api/");
});

builder.Services.AddDataProtection();

builder.Services.AddScoped<SecureIdService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSession();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authentication}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();
