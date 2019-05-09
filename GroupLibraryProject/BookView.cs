using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupLibraryProject
{
    class BookView
    {

        private string displayBook;


        public Book DisplayBook
        {
            set { displayBook = value; }
            get { return displayBook; }

        }


        public BookView(Book _displayBook)
        {
            DisplayBook = _displayBook;
        }


        public void Display()
        {

            //    Console.WriteLine("\n" +
            //        "Title : \n" + //displayBook.Title + 
            //        "Author : \n" + //displayBook.Author +
            //        "Genre : \n" + //displayBook.Type +
            //        "Due Date : "); //+ //displayBook.DueDate);
            //    Console.ReadLine();


            Console.WriteLine("\n" +
                "\n" +
                "\n" +
                "");

            string s = "Title : ";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (s.Length / 2)) + "}", s));
            string t = "Author : ";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (t.Length / 2)) + "}", t));
            string g = "Genre : ";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (g.Length / 2)) + "}", g));
            string d = "Due date : ";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (d.Length / 2)) + "}", d));
            string k = "Checked in/out : ";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (k.Length / 2)) + "}", k));
            Console.ReadLine();

        }


    }
}
