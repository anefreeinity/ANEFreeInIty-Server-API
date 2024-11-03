using ANEFreeInIty_Server_API.Extensions;
using ANEFreeInIty_Server_API.Extensions.Exceptions;

var builder = WebApplication.CreateBuilder(args);

var url = builder.Configuration["Kestrel:Endpoints:Http:Url"];
if (!string.IsNullOrEmpty(url))
{
    builder.WebHost.UseUrls(url);
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
