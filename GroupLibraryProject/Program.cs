using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupLibraryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] books = File.ReadAllLines(@"C:..\..\..\Books.txt");
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine(books[i]);
            }

            

        }
    }
}
