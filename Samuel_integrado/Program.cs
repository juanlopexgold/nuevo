using Samuel_integrado.Services.Interface;
using Samuel_integrado.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddSingleton<ICategoriaService, CategoriaService>();
builder.Services.AddControllers();
builder.Services.AddScoped<IModeloService, ModeloService>();

builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
// app.UseSwagger();
// app.UseSwaggerUI();
app.Run();
