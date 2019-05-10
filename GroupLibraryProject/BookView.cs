using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupLibraryProject
{
    class BookView
    {
        #region Fields
        private Book displayBook;
        #endregion

        #region Properties
        public Book DisplayBook
        {
            set { displayBook = value; }
            get { return displayBook; }

        }
        #endregion

        #region Constructor
        public BookView(Book _displayBook)
        {
            DisplayBook = _displayBook;
        }
        #endregion

        #region Methods
        public void Display()
        {

            Console.WriteLine();
            //To center text in the window
            string s = "Title : " + displayBook.Title;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (s.Length / 2)) + "}", s));
            string a = "Author : " + displayBook.Author;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (a.Length / 2)) + "}", a));
            string g = "Genre : " + displayBook.Type;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (g.Length / 2)) + "}", g));
            string d = "Due date : " + displayBook.DueDate.ToString("MM/dd/yyyy");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (d.Length / 2)) + "}", d));
            string c = "Checked out : " + displayBook.Status;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (c.Length / 2)) + "}", c));
            

        }
        #endregion


    }
}
