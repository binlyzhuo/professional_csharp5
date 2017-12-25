using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chpt25
{
    class Program
    {
        static void Main(string[] args)
        {
            AddStudent();
            Console.ReadLine();
        }

        static async void AddStudent()
        {
            Student student = new Student()
            {
                FirstName = "ff",
                LastName = "ss",
                Company = "ms"
            };

            StudentData studentData = new StudentData();
            Task<int> t = studentData.AddStudentAsync(student);

            int num = await t;

            await CommittableSamples.CommitTableTransactionAsync();
            Console.WriteLine(num);
        }
    }
}
