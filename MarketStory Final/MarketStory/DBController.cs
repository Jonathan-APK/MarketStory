using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketStory
{
    public class DBController
    {
        string connectionString = "server=localhost;database=marketstory;UID=root;password=2116;";

        public string getConnectionString()
        {
            return connectionString;
        }
    }
}