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
        private BookListView listView;
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
                Console.WriteLine("\t1. By Genre \n\t2. By Author\n\t3. By Title\n\t4. By Checkout Status\n\t5. Expected Returns \n\t6. All Books ");
                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1"://Genre
                        {
                            Console.WriteLine("Here are our available types of books:");
                            DisplayGenre();
                            break;
                        }
                    case "2"://Author
                        {
                            Console.WriteLine("Here are our list of available Authors:");
                            break;
                        }
                    case "3"://Title
                        {
                            Console.WriteLine("");
                            break;
                        }
                    case "4"://Status
                        {
                            break;
                        }
                    case "5"://Upcoming returns
                        {
                            break;
                        }
                    case "6":// All books
                        {
                            break;
                        }
                }

            }
            Console.WriteLine("\nThank you!");
        }
        public void DisplayGenre()
        {
            BookListView listView = new BookListView(bookDb);
            Console.WriteLine("\n\tYoung Adult\tThriller\tSatire");
            Console.WriteLine("\n\tRomantic\tFantasy\tChildren's Literature");
            Console.WriteLine("\n\tScience Fiction\tHistorical Fiction\tGothic Fiction");

            Console.WriteLine("Which type would like to see a list of?");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "Young Adult":
                    {
                        listView.DisplayType("Young Adult");
                        break;
                    }
                case "Thriller":
                    {
                        listView.DisplayType("Thriller");
                        break;
                    }
                case "Satire":
                    {
                        listView.DisplayType("Satire");
                        break;
                    }
                case "Romantic":
                    {
                        listView.DisplayType("Romantic");
                        break;
                    }
                case "Fantasy":
                    {
                        listView.DisplayType("Fantasy");
                        break;
                    }
                case "Children's Literature":
                    {
                        listView.DisplayType("Children's Literature");
                        break;
                    }
                case "Science Fiction":
                    {
                        listView.DisplayType("Science Fiction");
                        break;
                    }
                case "Historical Fiction":
                    {
                        listView.DisplayType("Historical Fiction");
                        break;
                    }
                case "Gotchic Fiction":
                    {
                        listView.DisplayType("Gotchic Fiction");
                        break;
                    }
                default:
                    break;

            }
        }
        public void CheckOut()
        {
            Console.WriteLine("Would you like to check out a book from this selection? (y/n)");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                Console.WriteLine("Which book would you like to check out?");
                string choice = Console.ReadLine();

                foreach (Book b in bookDb)
                {
                    if (b.Title.Contains(choice))
                    {
                        b.Status = true;
                    }

                }
            }
            else
            {

            }
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
