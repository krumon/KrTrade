using KrTrade.WebApp.Relational.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//// Add data base contexts
//builder.Services.AddDbContexts(builder.Configuration);

//builder.Services.AddDbContext<KrTradeDbContext>();
builder.Services.AddDbContext<KrTradeDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WorkConnection"), options =>
    {
        options.MigrationsAssembly("KrTrade.WebApp.Relational");
    });
});

//// Add ApplicationDbContext to DI
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

//// AddIdentity adds cookie based authentication
//// Adds scoped classes for things like UserManager, SignInManager, PasswordHashers etc..
//// NOTE: Automatically adds the validated user from a cookie to the HttpContext.User
//// https://github.com/aspnet/Identity/blob/85f8a49aef68bf9763cd9854ce1dd4a26a7c5d3c/src/Identity/IdentityServiceCollectionExtensions.cs
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    // Adds UserStore and RoleStore from this context
//    // That are consumed by the UserManager and RoleManager
//    // https://github.com/aspnet/Identity/blob/dev/src/EF/IdentityEntityFrameworkBuilderExtensions.cs
//    .AddEntityFrameworkStores<ApplicationDbContext>()

//    // Adds a provider that generates unique keys and hashes for things like
//    // forgot password links, phone number verification codes etc...
//    .AddDefaultTokenProviders();

//// Force Identity's security stamp to be validated every minute.
//builder.Services.Configure<SecurityStampValidatorOptions>(o =>
//                   o.ValidationInterval = TimeSpan.FromMinutes(1));

//builder.Services.Configure<PasswordHasherOptions>(option =>
//{
//    option.IterationCount = 12000;
//});

//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // Default Lockout settings.
//    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//    options.Lockout.MaxFailedAccessAttempts = 5;
//    options.Lockout.AllowedForNewUsers = true;
//    // Default Password settings.
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequiredLength = 6;
//    options.Password.RequiredUniqueChars = 1;
//    // Default SignIn settings.
//    options.SignIn.RequireConfirmedEmail = false;
//    options.SignIn.RequireConfirmedPhoneNumber = false;
//    // Default User settings.
//    options.User.AllowedUserNameCharacters =
//            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
//    options.User.RequireUniqueEmail = false;
//});

//// Add cookies configuration. This method should be called after AddIdentity or AddDefaultIdentity
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
//    options.Cookie.Name = "YourAppCookieName";
//    options.Cookie.HttpOnly = true;
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
//    options.LoginPath = "/Identity/Account/Login";
//    // ReturnUrlParameter requires 
//    //using Microsoft.AspNetCore.Authentication.Cookies;
//    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
//    options.SlidingExpiration = true;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
//b.DataSource = @"DESKTOP-VFT7HDS\SQLEXPRESS";
//b.InitialCatalog = "KrTradeDB";
//b.IntegratedSecurity = true;
////b.TrustServerCertificate = true;
////b.UserID = "sa";
////b.Password = "KrumonTrade-20";

//var cs = b.ConnectionString;

//using (SqlConnection c = new SqlConnection(cs))
//{
//    try
//    {
//        c.Open();
//        string state = c.State.ToString();
//        var id = c.ClientConnectionId;
//        var dataBase = c.Database;
//        using (SqlCommand cmd = c.CreateCommand())
//        {
//            cmd.CommandText = 
//                "create table TablaEmpresa " + 
//                "(" +
//                    "IdEmpresa int identity(1,1) primary key," +
//                    "RucEmpresa varchar(13)," +
//                    "RazonSocialEmp varchar(90)," +
//                    "NombreComercialEmp varchar(90)," +
//                    "TelefonoEmp1 varchar(14)," +
//                    "TelefonoEmp2 varchar(14)," +
//                    "CorreoEmp varchar(50)," +
//                    "CiudadEmp varchar(25)," +
//                    "DireccionEmp varchar(150)," +
//                    "ActividadEconomica varchar(300)" + 
//                ")";
//            cmd.CommandType = CommandType.Text;
//            var rows = cmd.ExecuteNonQuery();
//        }

//    }
//    catch (Exception ex)
//    {

//        throw;
//    }
//    finally
//    {
//        c.Close();
////    }

//}

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetService<KrTradeDbContext>();
//    context?.Database.GetDbConnection().Open();


//    context?.Database.GetDbConnection().Close();
//}


app.Run();
