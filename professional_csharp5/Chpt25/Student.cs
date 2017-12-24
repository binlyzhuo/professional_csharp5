using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chpt25
{
    [Serializable]
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}
