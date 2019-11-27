using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulbul_1249211_Ex_06
{
    public static class ConnectionHelper
    {
        public static string ConnectionString
        {
            get
            {
                return @"Data Source = (localdb)\MSSQLLOCALDB; AttachDbFileName =" + Path.GetFullPath(@"..\..\") + "Labordb.mdf;Trusted_Connection = True;MultipleActiveResultSets=true";
            }
        }
    }
}
