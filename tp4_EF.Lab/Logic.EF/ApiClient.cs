using Entities.EF;
using Logic.EF.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.EF
{
    public class ApiClient : ICountries
    {
        public List<Country> GetCountries()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://api.countrylayer.com/v2/all?access_key=6ff815c4a95063d613ae7a99ee7ee38a");
            
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            string responseFrom = reader.ReadToEnd();
                            List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(responseFrom);
                            return countries;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}
