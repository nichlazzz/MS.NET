using Restoraunt.Restoraunt.Service.Settings;

namespace Restoraunt.Restoraunt.Service.UnitTests.Helpers;

public static class TestSettingsHelper
{
    public static RestorauntSettings GetSettings()
    {
        return RestorauntSettingsReader.Read(ConfigurationHelper.GetConfiguration());
    }
}