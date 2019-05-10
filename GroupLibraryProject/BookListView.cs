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
        public void DisplayAuthor(List<Book> bookList, string author)
        {
            foreach (Book book in bookList)
            {
                if (book.Author == author)
                {
                    Console.WriteLine($" {book.Author}");
                }
            }

        }
        public void DisplayTitle(List<Book> bookList, string title)
        {
            foreach (Book book in bookList)
            {
                if (book.Title == title)
                {
                    Console.WriteLine($" {book.Title}");
                }
            }
        }
        public void DisplayStatus(List<Book> bookList, string status)
        {
            foreach (Book book in bookList)
            {
                if (book.Status == status)
                {
                    Console.WriteLine($" {book.Status}");
                }
            }
        }
        public void DisplayDueDate(List<Book> bookList, DateTime dueDate)
        {
            foreach (Book book in bookList)
            {
                if (book.DueDate == dueDate)
                {
                    Console.WriteLine($" {book.DueDate}");
                }
            }
        }
    }
}
















