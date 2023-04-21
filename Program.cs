
var webApplicationOptions = new WebApplicationOptions() { ContentRootPath = AppContext.BaseDirectory, Args = args, ApplicationName = System.Diagnostics.Process.GetCurrentProcess().ProcessName };
var builder = WebApplication.CreateBuilder(webApplicationOptions);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
