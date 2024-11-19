
using Restoraunt.Restoraunt.Service.IoC;
using Restoraunt.Restoraunt.Service.Settings;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Configure application settings
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();
var settings = RestorauntSettingsReader.Read(configuration); 

// Register services
builder.Services.AddControllers();

// // Register your custom configurators
// AuthorizationConfigurator.ConfigureServices(builder.Services, settings);
// DbContextConfigurator.ConfigureService(builder.Services, settings);
// SerilogConfigurator.ConfigureService(builder);
// SwaggerConfigurator.ConfigureServices(builder.Services);
// MapperConfigurator.ConfigureServices(builder.Services);
// ServicesConfigurator.ConfigureService(builder.Services, settings);

// Build the application
var app = builder.Build();

// // Configure application-level middleware
// SerilogConfigurator.ConfigureApplication(app);
// SwaggerConfigurator.ConfigureApplication(app);
// DbContextConfigurator.ConfigureApplication(app);
// AuthorizationConfigurator.ConfigureApplication(app);
//
// // Configure routing and middleware
// app.UseHttpsRedirection();
// app.UseAuthorization();
// app.MapControllers(); // create graph - search by url //localhost/users/id GET

// Run the application
app.Run();

