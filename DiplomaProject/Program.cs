using DiplomaProject.BackWorkers;
using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.OpenDotaAPI.ApiParsers;
using DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations;
using DiplomaProject.Services;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Sdk;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDotaAPIService, OpenDotaApiService>();
builder.Configuration.AddJsonFile("APIConfig.json");
builder.Configuration.AddJsonFile("prettyItem.json");
var app = builder.Build();

app.MapGet("/test", async (IDotaAPIService c,HttpContext cs) => Test(c, cs));
app.MapGet("/", async (IDotaAPIService c,HttpContext cs) => Test1(c, cs));

app.Run();


void Test(IDotaAPIService c,HttpContext cs) {
    
    IAPIModel ci = c.GetMacth1(7143520855);
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
