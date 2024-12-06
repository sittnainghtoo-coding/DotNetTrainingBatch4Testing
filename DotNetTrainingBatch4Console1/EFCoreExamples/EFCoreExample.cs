using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch4Console1.EFCoreExamples
{
    public class EFCoreExample
    {
        private readonly AppDbContext _db = new AppDbContext();
        public void Read()
        {
            var lst = _db.Blogs.ToList();
            foreach (var item in lst) { 
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Author);
                Console.WriteLine(item.Content);

            }

        }

        public void Edit(string id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            Console.WriteLine(item.Id);
            Console.WriteLine(item.Title);
            Console.WriteLine(item.Author);
            Console.WriteLine(item.Content);

        }



    }


}
