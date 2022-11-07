using dominando_injecao_de_dependencia.Extensions;
using dominando_injecao_de_dependencia.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Configuration>();

builder.Services.AddSqlConnection(builder.Configuration.GetConnectionString("Default connection"));

builder.Services.AddRepository();

builder.Services.AddService();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
