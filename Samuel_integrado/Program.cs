using Interface;
using Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


builder.Services.AddSingleton<IModeloService, ModeloServices>();
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
// app.UseSwagger();
// app.UseSwaggerUI();
app.Run();
