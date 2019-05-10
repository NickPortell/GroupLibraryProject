using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupLibraryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Book q = new Book("blah", "blah blah", DateTime.Parse("12/12/2019"), "blah blah blah", "blah blah blah blah");

            Console.WriteLine("\n" +
                "\n" +
                "\n" +
                "");
            //To center text in the window
            string s = "Title : " + q.Title;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (s.Length / 2)) + "}", s));
            string a = "Author : " + q.Author;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (a.Length / 2)) + "}", a));
            string g = "Genre : " + q.Type;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (g.Length / 2)) + "}", g));
            string d = "Due date : " + (q.DueDate).ToString("MM/dd/yyyy");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (d.Length / 2)) + "}", d));
            string c = "Checked in/out : " + q.Status;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (c.Length / 2)) + "}", c));
            Console.ReadLine();


        }
    }
}
