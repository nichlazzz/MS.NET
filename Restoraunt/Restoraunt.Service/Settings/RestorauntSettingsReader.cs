namespace Restoraunt.Restoraunt.Service.Settings
{
    public static class RestorauntSettingsReader
    {
        public static RestorauntSettings Read(IConfiguration configuration)
        {
            return new RestorauntSettings()
            {
                ServiceUri = configuration.GetValue<Uri>("Uri"),
                RestorauntDbContextConnectionString = configuration.GetValue<string>("RestorauntDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            };
        }
    }
}