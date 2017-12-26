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

        public static void TransactionPromotion()
        {
            var tx = new CommittableTransaction();
            Utility.DisplayTransactionInfo("TX Created",tx.TransactionInformation);

            try
            {
                var db = new StudentData();
                var s1 = new Student()
                {
                    FirstName = "Z1",LastName = "ff", Company = "fff"
                };

                db.AddStudent(s1, tx);

                var s2 = new Student()
                {
                    FirstName = "first0", LastName = "last", Company = "COM"
                };

                db.AddStudent(s2,tx);
                Utility.DisplayTransactionInfo("2nd connection enlished",tx.TransactionInformation);
                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                tx.Rollback();
            }

        }
    }
}
