using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.Services;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDotaAPIService, OpenDotaApiService>();
builder.Configuration.AddJsonFile("prettyItem.json");
builder.Configuration.AddJsonFile("APIConfig.json");
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();
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
