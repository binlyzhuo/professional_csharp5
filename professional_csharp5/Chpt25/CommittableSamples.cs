using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Chpt25
{
    public class CommittableSamples
    {
        public static async Task CommitTableTransactionAsync()
        {
            var tx = new CommittableTransaction();
            Utility.DisplayTransactionInfo("Tx Created",tx.TransactionInformation);

            try
            {
                var s1 = new Student()
                {
                    FirstName = "Wei",LastName = "EN",Company = "WN"
                };

                var db = new StudentData();
                await db.AddStudentAsync(s1, tx);

                //if()
                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                tx.Rollback();
            }

            Utility.DisplayTransactionInfo("Tx Completed:",tx.TransactionInformation);
        }
    }
}
