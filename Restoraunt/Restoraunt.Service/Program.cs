using Restoraunt.Restoraunt.Service.DI;
using Restoraunt.Restoraunt.Service.IoC;
using Restoraunt.Restoraunt.Service.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = RestorauntSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

ApplicationConfigurator.ConfigureServices(builder, settings);

var app = builder.Build();

ApplicationConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();
AuthorizationConfigurator.ConfigureApplication(app);
app.MapControllers();

app.Run();