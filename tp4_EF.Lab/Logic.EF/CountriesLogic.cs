using Logic.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.EF;



namespace Logic.EF
{
    public class CountriesLogic
    {
        private ICountries countryAPI { get; set; }

        public CountriesLogic(ICountries countryAPI)
        {
            this.countryAPI = countryAPI;
        }
        public List<Country> GetCountries()
        {
            try
            {
                return (from c in countryAPI.GetCountries()
                        select new Country
                        {
                            Name = c.Name,
                            Capital = c.Capital,
                            Region = c.Region,
                            
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
