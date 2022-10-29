var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Configuration>();
builder.Services.AddScoped(x => new SqlConnection("CONN_STRING"));
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
builder.Services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
