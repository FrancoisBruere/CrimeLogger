using Business.Repository;
using Business.Repository.IRepository;
using CrimeLogger.Server.Helper;
using CrimeLoggger_Server.Helper;
using DataAccess.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var appSettingSection = builder.Configuration.GetSection("APISettings");
builder.Services.Configure<APISettings>(appSettingSection);

builder.Services.Configure<MailJetSettings>(builder.Configuration.GetSection("MailJetSettings"));


var apiSettings = appSettingSection.Get<APISettings>(); // pupulate key
var key = Encoding.ASCII.GetBytes(apiSettings.SecretKey);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = apiSettings.ValidAudience,
        ValidIssuer = apiSettings.ValidIssuer,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero

    };
});

builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedEmail = true;
    opt.Password.RequiredLength = 6;
    

});
builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
                 opt.TokenLifespan = TimeSpan.FromDays(2));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICrimeDetailRepository, CrimeDetailRepository>();
builder.Services.AddScoped<ICrimeProvinceRepository, CrimeProvinceRepository>();
builder.Services.AddScoped<ICrimeCityRepository, CrimeCityRepository>();
builder.Services.AddScoped<ICrimeSuburbRepository, CrimeSuburbRepository>();
builder.Services.AddScoped<ICrimeTypeRepository, CrimeTypeRepository>();
builder.Services.AddScoped<IUserUpdateRepository, UserUpdateRepository>();



builder.Services.AddScoped<IEmailSender, EmailSender>();


builder.Services.AddRouting(option => option.LowercaseUrls = true);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    app.MapRazorPages();
    app.MapControllers();
    app.MapFallbackToFile("index.html");
});

app.Run();
