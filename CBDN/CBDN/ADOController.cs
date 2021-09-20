using System.Configuration;
namespace CBDN
{
    public class ADOController
    {
        public string strcn()
        {
            //return "Data Source=10.21.0.135;Initial Catalog=TESTGNDN;User ID=sa;Password=pcnpm@2018;MultipleActiveResultSets=True;";
            return ConfigurationSettings.AppSettings["ConnectionInfo"];
        }

    }
   }