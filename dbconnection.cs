using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace fingerpriintbasedatm
{
    class dbconnection
    {
        public static readonly SqlConnection conn = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=Fingerprint_Billing;Integrated Security=True;");
    
    }
}
