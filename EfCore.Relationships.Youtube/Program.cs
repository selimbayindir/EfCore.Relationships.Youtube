using EfCore.Relationships.Youtube.Context;
using EfCore.Relationships.Youtube.Dtos;
using EfCore.Relationships.Youtube.Models;
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
//1.yol 
app.MapPost("user-create", (ApplicationDbContext context, UserCreateDto request)
    =>
{

    User user = new User()
    {
        FirstName = request.FirstName,
        LastName = request.LastName,
        UserInformation = new()
        {
            IdentityNumber = request.IdentityNumber,
            FullAddress = request.FullAddress,
        }
    };
    context.Add(user);
    context.SaveChanges();
    return Results.Ok(user);
});
//---
////Ýliþkili eklemek için uzun 2.yol 
//app.MapPost("user-create", (ApplicationDbContext context, UserCreateDto request) =>
//{

//    User user = new User()
//    {
//        FirstName = request.FirstName,
//        LastName = request.LastName,

//    };
//    UserInformation userInformation = new UserInformation()
//    {
//        IdentityNumber = request.IdentityNumber,
//        FullAddress = request.FullAddress,
//        UserId = user.Id
//    };
//    user.UserInformationId = userInformation.Id;    
//    context.Add(user);
//    context.Add(userInformation);
//    context.SaveChanges();
//    return Results.Ok(user);
//});
//----------------------------------------------------------------------
//-----------------------Listeleme--------------------------------------
//----------------------------------------------------------------------
//app.MapGet("user-getall", (ApplicationDbContext context) =>
//{
//    var users = context.Users.ToList();
//    return users;
//});
//Bu Doðrudur ancak UserýNFORMATÝON BÝLGÝLERÝNÝNDE GELMESÝ ÝÇÝN Ýnclude kullanmalýsýn 
app.MapGet("user-getall", (ApplicationDbContext context) =>
{
    var users = context.Users.Include(p =>p.UserInformation).ToList(); //UserInformation Navigation Property verilir left join yapmýþýz gibi
    return users;
});
app.Run();
