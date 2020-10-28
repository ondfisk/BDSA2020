namespace Lecture08.Models.Singleton
{
    public interface IConfig
    {
        string ClientId { get; }
        string ClientSecret { get; }
    }

    public class HardcodedConfig : IConfig
    {
        public string ClientId => "11cd234e-4bf1-43ca-8607-c0022a92cba1";

        public string ClientSecret => "/ZBL7gahFns8OV+whliNQGZt/RjdM14Iw35mGi87rOo=";

        // public static HardcodedConfig Instance { get; }

        // static HardcodedConfig()
        // {
        //     Instance = new HardcodedConfig();
        // }

        // private HardcodedConfig()
        // {
        // }
    }
}
