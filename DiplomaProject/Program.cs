using DiplomaProject.DataBase;
using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
        .AddCookie(options =>
        {
            options.LoginPath = "/login";
            options.LogoutPath = "/signout";
        })
        .AddSteam();
var connectionstring = "server=localhost;user=root;password=;database=testdb;";
builder.Services.AddDbContext<ApplicationContext>(x =>
x.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring),options => options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: System.TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null)
                ));
builder.Services.AddTransient<IDotaAPIService, OpenDotaApiService>();
builder.Configuration.AddJsonFile("prettyItem.json");
builder.Configuration.AddJsonFile("heroes.json");
builder.Configuration.AddJsonFile("APIConfig.json");
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//builder.Services.AddHostedService<BackGroundReactionCounter>();
var app = builder.Build();
app.UseStatusCodePagesWithRedirects("/");
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
app.UseStaticFiles();

app.MapControllers();

app.Run();


void Test(IDotaAPIService c,HttpContext cs) {
    
    IAPIModel ci = c.GetMacth(7143520855);
    cs.Response.ContentType = "application/json";
    var jsonObject = JsonConvert.SerializeObject(ci);
    cs.Response.WriteAsync(jsonObject, Encoding.UTF8);
}
void Test1(IDotaAPIService c, HttpContext cs)
{
    IAPIModel ci = c.GetAccountInfo(227037030);
    cs.Response.ContentType = "application/json";
    var jsonObject = JsonConvert.SerializeObject(ci);
    cs.Response.WriteAsync(jsonObject, Encoding.UTF8);
}
