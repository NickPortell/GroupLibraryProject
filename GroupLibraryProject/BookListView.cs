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
        public static void DisplayType(List<Book> bookList,string type)
        {
            foreach(Book book in bookList)
            {
                if(book.Type==type)
                {
                    Console.WriteLine($"{book.Type}");
                }
            }










            public static void GetMovie(List<Movie> movies, string Category)
            {
                foreach (Movie movie in movies)
                {
                    if (movie.Category == Category)
                    {
                        Console.WriteLine($"{movie.Category} movie: {movie.Title}");
                    }
                    //switch (type)
                    //{
                    //    case "Drama":
                    //        Console.WriteLine("You are looking for a Drama Book");
                    //        break;
                    //    case "Scifi":
                    //        Console.WriteLine("You are looking for a Scifi");
                    //        break;
                    //    case "Romance":
                    //        Console.WriteLine("You are looking for a Romance");
                    //        break;
                    //    case "Horror":
                    //        Console.WriteLine("You are looking for a Horror");
                    //        break;
                    //    default:
                    //        break;

                    foreach (Book book in books)
                    {
                        
                    }

                    }
            }
        }

        }
    }

