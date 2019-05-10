using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupLibraryProject
{
    class BookListView
    {
        // LOOK I MADE COOL CHANGES!!
        private List<Book> books;
        private BookView view;

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
        public void DisplayType(string type)
        {
            
            foreach (Book book in books)
            {
                view = new BookView(book);
                if (book.Type == type)
                {
                    view.Display();
                }
            }
        }
        public void DisplayAuthor(string author)
        {
            foreach(Book book in books)
            {
                view = new BookView(book);
                if (book.Author == author)
                {
                    view.Display();
                }
            }
          
        }
        public void DisplayTitle(string title)
        {
            foreach(Book book in books)
            {
                view = new BookView(book);
                if(book.Title.Contains(title))
                {
                    view.Display();
                }
            }
        }
        public void DisplayStatus(bool status)
        {

            foreach (Book book in books)
            {
                view = new BookView(book);
                if (book.Status == status)
                {
                    view.Display();
                }
            }
        }
        public void DisplayDueDate(DateTime dueDate)
        {
            foreach (Book book in books)
            {
                if (book.DueDate == dueDate)
                {
                    Console.WriteLine($" {book.DueDate}");
                }
            }
        }

        }
    }
}














