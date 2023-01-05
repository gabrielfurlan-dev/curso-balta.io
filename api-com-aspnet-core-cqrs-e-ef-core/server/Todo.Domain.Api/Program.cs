using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Commands.Handlers;
using ToDo.Domain.Infra.Contexts;
using ToDo.Domain.Infra.Repositories.ToDo;
using ToDo.Domain.Repositories.Contracts;
using Microsoft.IdentityModel.Tokens;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        // builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer("Data Source=DESKTOP-2BDQ1GT;Initial Catalog=ToDos;User ID=sa; pwd=adrvsc"));
        builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
        builder.Services.AddTransient<IToDoRepository, ToDoRepository>();
        builder.Services.AddTransient<CreateToDoHandler, CreateToDoHandler>();
        builder.Services.AddTransient<MarkTodoAsDoneHandler, MarkTodoAsDoneHandler>();
        builder.Services.AddTransient<MarkTodoAsUndoneHandler, MarkTodoAsUndoneHandler>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Authority = "https://securetoken.google.com/apiaspnettodo";
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "https://securetoken.google.com/apiaspnettodo",
                ValidateAudience = true,
                ValidAudience = "apiaspnettodo",
                ValidateLifetime = true
            };
        });

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors(x => x.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin());
        app.UseAuthorization();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
        app.MapControllers();
        app.Run();
    }
}