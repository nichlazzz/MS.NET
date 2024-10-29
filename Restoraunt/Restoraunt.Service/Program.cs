
using Restoraunt.Restoraunt.Service.IoC;
using Serilog;
var configuration = new ConfigurationBuilder()
    .AddJsonFile("/Users/a123/RiderProjects/MS.NET/Restoraunt/appsettings.json", optional: false)
    .Build();

//var settings = LostPropertyOfficeSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//DbContextConfigurator.ConfigureService(builder.Services, settings);
SerilogConfigurator.ConfigureService(builder);
SwaggerConfigurator.ConfigureServices(builder.Services);

var app = builder.Build();

//SerilogConfigurator.ConfigureApplication(app);
//SwaggerConfigurator.ConfigureApplication(app);
//DbContextConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();