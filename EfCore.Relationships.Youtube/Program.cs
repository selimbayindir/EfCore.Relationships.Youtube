using EfCore.Relationships.Youtube.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//service registration
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        string connectionString = builder.Configuration.GetConnectionString("MssqlMy") ?? "";
        //string?
        //veya sonuna ! koyarsan kesinlikle null gelmeyecek demektir.
        options.UseSqlServer(connectionString);

    });




var app = builder.Build();

app.MapGet("/", () => "Hello World!");
//middleware

app.Run();
