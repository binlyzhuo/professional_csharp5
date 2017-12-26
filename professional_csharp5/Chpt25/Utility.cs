using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Chpt25
{
    public static class Utility
    {
        public static void DisplayTransactionInfo(string title, TransactionInformation ti)
        {
            //Contract.Requires<ArgumentNullException>(ti != null);

            Console.WriteLine(title);
            Console.WriteLine("CreateTime:{0}",ti.CreationTime);
            Console.WriteLine("Local ID:{0}",ti.LocalIdentifier);
            Console.WriteLine("Distributed ID:{0}",ti.DistributedIdentifier);
        }

        public static bool AbortTx()
        {
            Console.WriteLine("Abort the Transaction (y/n)?");
            return Console.ReadLine().ToLower().Equals("y");
        }
    }
}
