using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chpt10
{
    public class Racer : IComparable<Racer>, IFormattable
    {
        public int Id { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string Country { set; get; }

        public int Wins { set; get; }

        public Racer(int id, string firstName, string lastName, string country, int wins)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.Wins = wins;
        }

        public Racer(int id, string firstName, string lastName, string country)
            : this(id, firstName, lastName, country, wins: 0)
        {

        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{FirstName} {LastName}";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                format = "N";

            switch (format.ToUpper())
            {
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "W":
                    return string.Format("{0},Wins:{1}",ToString(),Wins);
                case "C":
                    return string.Format("{0},Country:{1}",ToString(),Country);
                case "A":
                    return string.Format("{0},{1} Wins:{2}",ToString(),Country,Wins);

                default:
                    throw new FormatException(string.Format(formatProvider, "Format {0} is not support!",format));

            }

        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public int CompareTo(Racer other)
        {
            if (other == null)
                return -1;
            int compare = string.Compare(this.LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
            if (compare == 0)
                return string.Compare(this.FirstName, other.FirstName,StringComparison.OrdinalIgnoreCase);

            return compare;
        }
    }
}
