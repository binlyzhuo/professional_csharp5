using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chpt10
{
    public class MyClass:IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("object dispose~");
        }
    }
}
