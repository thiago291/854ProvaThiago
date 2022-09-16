using Trabalho_Final_ProgWebIII.Core.Interface;
using Trabalho_Final_ProgWebIII.Core.Service;
using Trabalho_Final_ProgWebIII.Infra.Data.Repository;
using Trabalho_Final_ProgWebIII.Filters;

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

builder.Services.AddScoped<ICityEventService, CityEventService>();
builder.Services.AddScoped<ICityEventRepository, CityEventRepository>();
builder.Services.AddScoped<IEventReservationService, EventReservationService>();
builder.Services.AddScoped<IEventReservationRepository, EventReservationRepository>();
builder.Services.AddScoped<GaranteEventoActionFilter>();
builder.Services.AddScoped<GaranteReservaActionFilter>();

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
