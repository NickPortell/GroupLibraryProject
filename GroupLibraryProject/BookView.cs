using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupLibraryProject
{
    class BookView
    {

        private Book displayBook;


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
            //To center text in the window
            string s = "Title : " + displayBook.Title;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (s.Length / 2)) + "}", s));
            string a = "Author : " + displayBook.Author;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (a.Length / 2)) + "}", a));
            string g = "Genre : " + displayBook.Type;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (g.Length / 2)) + "}", g));
            string d = "Due date : " + displayBook.DueDate.ToString("MM/dd/yyyy");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (d.Length / 2)) + "}", d));
            string c = "Checked in/out : " + displayBook.Status;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (c.Length / 2)) + "}", c));
            Console.ReadLine();

        }


    }
}
