using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace DataAccessLayer.API
{
    public static class FlurlHttpClient
    {
        public static async Task<IList<dynamic>> GetApiDataAsync()
        {   
            return await "https://world-cup-json-2018.herokuapp.com/matches".GetJsonAsync<IList<dynamic>>();
        }
    }
}
