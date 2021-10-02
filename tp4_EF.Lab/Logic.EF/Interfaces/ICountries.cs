using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.EF.Interfaces
{
    public interface ICountries
    {
        List<Country> GetCountries();
    }
}
