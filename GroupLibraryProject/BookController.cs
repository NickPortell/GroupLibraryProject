using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupLibraryProject
{
    class BookController
    {
        #region Fields
        private List<Book> bookDb;
        #endregion

        #region Properties
        public List<Book> BookDb
        {
            set { bookDb = value; }
            get { return bookDb; }
        }
        #endregion

        #region Constructors
        
        #endregion

        #region Methods
        public void BookAction(Book b)
        {
            BookView view = new BookView(b);
            view.Display();
        }

        public void WelcomeAction()
        {
            string response = "yes";


            BookListView listView = new BookListView(bookDb);
            Console.WriteLine("Hello, welcome to the Grand Circus Library!");

            while (response == "yes")
            {
                //Maybe prompt a rotating selection of 'popular' books as a 'book of the day or hotest author'.
                Console.WriteLine("Here are some browsing/search options:");
                Console.WriteLine("\t1. By Genre \n\t2. By Author\n\t3. By Title\n\t4. By Checkout Status\n\t5. Expected Returns ");
                
            }
            Console.WriteLine("\nThank you!");
        }
        #endregion

        #region Validation Method
        public string isValid(int max)
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int num))
            {
                Console.Clear();
                Console.WriteLine($"{input} is not a valid option. Please choose a number from 0-{bookDb.Count - 1}\n");
                Console.WriteLine("==================================================================");
                return isValid(max);
            }
            else if (num < 0 || num > max)
            {
                Console.Clear();
                Console.WriteLine($"{input} is not a valid option. Please choose a number from 0-{bookDb.Count - 1}\n");
                Console.WriteLine("==================================================================");
                return isValid(max);
            }
            return input;

        }
        #endregion


    }
}
