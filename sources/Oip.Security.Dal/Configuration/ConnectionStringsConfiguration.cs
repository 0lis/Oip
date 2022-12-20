namespace Oip.Security.Dal.Configuration.Configuration;

public class ConnectionStringsConfiguration
{
    public string ConfigurationDbConnection { get; set; }


    public void SetConnections(string commonConnectionString)
    {
        ConfigurationDbConnection = commonConnectionString;
    }
}