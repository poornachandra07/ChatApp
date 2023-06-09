
using ChatApp.HubContext;

var webApplicationOptions = new WebApplicationOptions() { ContentRootPath = AppContext.BaseDirectory, Args = args, ApplicationName = System.Diagnostics.Process.GetCurrentProcess().ProcessName };
var builder = WebApplication.CreateBuilder(webApplicationOptions);

// Add services to the container.

builder.Services.AddSingleton<ChatHub>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors(policy => policy.AddPolicy("policy", 
    options => options
    //.WithOrigins("http://localhost:4200/")
    .AllowAnyOrigin()
    .AllowAnyHeader()
    //.AllowCredentials()
    .AllowAnyMethod()));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/signalr").RequireCors("policy");
app.UseCors("policy");

app.Run();
