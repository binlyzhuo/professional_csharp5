using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chpt10
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "abc0";
            string s2 = "abc00";

            int compare = string.Compare(s1, s2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine(compare);

            Racer racer = new Racer(1,"ZZ","DD","ZH",10);
            Console.WriteLine(racer.ToString("A"));

            Console.ReadLine();
        }
    }
}
