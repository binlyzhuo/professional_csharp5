using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chpt10
{
    public class ProcessDocuments
    {
        private DocumentManager documentManager;

        public static void Start(DocumentManager dm)
        {
            Task.Factory.StartNew(new ProcessDocuments(dm).Run);
        }

        protected ProcessDocuments(DocumentManager dm)
        {
            if(dm==null)
                throw new ArgumentNullException("dm");

            documentManager = dm;
        }

        protected void Run()
        {
            while (true)
            {
                if (documentManager.IsDocumentAvaiable)
                {
                    Document doc = documentManager.GetDocument();
                    Console.WriteLine("Processing document {0}",doc.Title);
                }

                Thread.Sleep(new Random().Next(20));
            }
        }
    }
}
