using System.Configuration;

namespace WsFotosColetor
{
    public class Configs
    {
        public static string StringConexao()
           => ConfigurationManager.ConnectionStrings["StringConexaoOracle"].ConnectionString;
    }
}