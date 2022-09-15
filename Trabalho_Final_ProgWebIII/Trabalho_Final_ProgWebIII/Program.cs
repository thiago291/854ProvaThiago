using Trabalho_Final_ProgWebIII.Core.Interface;
using Trabalho_Final_ProgWebIII.Core.Service;
using Trabalho_Final_ProgWebIII.Infra.Data.Repository;
//using Trabalho_Final_ProgWebIII.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddMvc(options =>
//{
//    options.Filters.Add<LogResultFilter>();
//    options.Filters.Add<GeneralExceptionFilter>();
//    options.Filters.Add<LogTimeFilter>();
//}
//    );

builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
//builder.Services.AddScoped<GaranteProdutoClienteActionFilter>();
//builder.Services.AddScoped<CPFNaoEstaDuplicadoActionFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
