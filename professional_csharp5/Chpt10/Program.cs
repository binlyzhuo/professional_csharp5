using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            List<Racer> racerList = new List<Racer>();
            racerList.Add(racer);

            var person = racerList.ConvertAll<Person>(r => new Person(r.FirstName + "" + r.LastName));

            //================
            var dm = new DocumentManager();
            ProcessDocuments.Start(dm);

            for (int i = 0; i < 100; i++)
            {
                var doc = new Document("Doc"+i.ToString(),"content");
                dm.AddDocument(doc);
                Console.WriteLine("Add document {0}",doc.Title);
                Thread.Sleep(new Random().Next(20));
            }

            var alphabet = new Stack<char>();

            alphabet.Push('A');
            alphabet.Push('B');
            alphabet.Push('C');

            Console.WriteLine("First ieration:");

            foreach (var item in alphabet)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Second iteration:");
            while (alphabet.Count>0)
            {
                Console.WriteLine(alphabet.Pop());
            }

            //int aAscii = 'A';

            Console.ReadLine();
        }
    }
}
