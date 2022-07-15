using CalculadoraIR.Presentation;
using CalculadoraIR.Services;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main()
    {
        ServiceCollection services = new();
        ConfigureServices(services);

        var serviceProvider = services.BuildServiceProvider();
        var mainFlow = serviceProvider.GetService<IScreen>();
        mainFlow.MainMenu();
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IScreen, Menu>()
                .AddScoped<ITaxCalculator, TaxCalculation>();
    }
}