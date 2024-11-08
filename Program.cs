using ANEFreeInIty_Server_API.Extensions;
using ANEFreeInIty_Server_API.Extensions.Exceptions;

var builder = WebApplication.CreateBuilder(args);

var httpUrl = builder.Configuration["Kestrel:Endpoints:Http:Url"];
var httpsUrl = builder.Configuration["Kestrel:Endpoints:Https:Url"];
if (!string.IsNullOrEmpty(httpUrl) && !string.IsNullOrEmpty(httpsUrl))
{
    builder.WebHost.UseUrls(httpUrl, httpsUrl);
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.ConfigureCors();
builder.Services.ConfigureUploadLimit();
builder.Services.ConfigureDBConnection(builder.Configuration);
builder.Services.InjectRepository();
builder.Services.InjectService();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandler();
app.UseHttpsRedirection();
app.MapControllers();
app.UseCors("CorsPolicy");

app.Run();
