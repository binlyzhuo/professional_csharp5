using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chpt10
{
    public class FindCountry
    {
        private string country;
        public FindCountry(string country)
        {
            this.country = country;
        }

        public bool FindCountryPredicate(Racer racer)
        {
            return racer.Country == country;
        }
    }
}
