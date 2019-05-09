using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupLibraryProject
{
    class BookListView
    {
        private List<Book> books;

        public List<Book> Books
        {
            set { books = value; }
            get { return books; }
        }
        public BookListView(List<Book> _books)
        {
            books = _books;
        }
        public BookListView()
        {

        }
        public void Display()
        {
            int count = 0;
            foreach (Book book in books)
            {
                Console.WriteLine(book);
                count++;
            }
        }
        public void DisplayType(List<Book> bookList, string type)
        {


            foreach (Book book in bookList)
            {
                if (book.Type == type)
                {
                    Console.WriteLine($"{book.Type}");
                }
            }




        }
    }
}














