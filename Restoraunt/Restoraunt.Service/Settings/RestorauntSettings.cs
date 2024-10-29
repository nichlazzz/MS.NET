namespace Restoraunt.Restoraunt.Service.Settings
{
    public class RestorauntSettings
    {
        public Uri ServiceUri { get; set; }
        public string RestorauntDbContextConnectionString { get; set; }
        public int MinimumTrainerAge { get; set; } = 18;
        public string IdentityServerUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
