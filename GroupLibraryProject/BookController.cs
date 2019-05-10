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
        public BookController(BookListView _listView)
        {
            listView = _listView;

        }
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
            Console.WriteLine("Hello, welcome to the Grand Circus Library!");// Maybe put this in Main?

            while (response == "yes")
            {
                //Maybe prompt a rotating selection of 'popular' books as a 'book of the day or hotest author'.
                Console.WriteLine("Here are some browsing/search options:");
                Console.WriteLine("\t1. By Genre \n\t2. By Author\n\t3. By Specific Title\n\t4. By Checkout Status\n\t5. Expected Returns \n\t6. All Books \n\t7. Quit");
                string choice = Console.ReadLine();

                if (int.TryParse(choice, out int num))
                {
                    switch (num)
                    {
                        case 1://Genre
                            {
                                Console.WriteLine("Here are our available types of books:");
                                DisplayGenre();
                                break;
                            }
                        case 2://Author
                            {
                                Console.WriteLine("Here are our list of available Authors:");
                                DisplayAuthor();
                                break;
                            }
                        case 3://Title
                            {
                                Console.WriteLine("What is the specific Title for a book you are looking for?");
                                DisplayTitle();
                                break;
                            }
                        case 4://Status
                            {
                                Console.WriteLine("What kind of books would you like to see:");
                                DisplayStatus();
                                break;
                            }
                        case 5://Upcoming returns
                            {
                                Console.WriteLine("Here are books who are 'checked out', but estimated to be returned within the next two weeks: ");
                                DisplayDate();
                                break;
                            }
                        case 6:// All books
                            {
                                Console.WriteLine("Here is our selection of ALL books in alphabetical order: ");
                                listView.Display();
                                CheckOut();
                                break;
                            }
                        case 7:// Quit
                            {
                                Console.WriteLine("Thank you for stopping by!");
                                response = "no";
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("invalid input! Please enter a valid number between 1-7 \n\t(Please try again)");
                                WelcomeAction();
                                break;
                            }
                            
                    }
                }
                else
                {
                    Console.WriteLine("invalid input! Please enter a valid number between 1-7 \n\t(Please try again)");
                    WelcomeAction();
                }
                Console.Clear();
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
                        Console.Clear();
                        listView.DisplayType("Young Adult");
                        CheckOut();
                        break;
                    }
                case "Thriller":
                    {
                        Console.Clear();
                        listView.DisplayType("Thriller");
                        CheckOut();
                        break;
                    }
                case "Satire":
                    {
                        Console.Clear();
                        listView.DisplayType("Satire");
                        CheckOut();
                        break;
                    }
                case "Romantic":
                    {
                        Console.Clear();
                        listView.DisplayType("Romantic");
                        CheckOut();
                        break;
                    }
                case "Fantasy":
                    {
                        Console.Clear();
                        listView.DisplayType("Fantasy");
                        CheckOut();
                        break;
                    }
                case "Children's Literature":
                    {
                        Console.Clear();
                        listView.DisplayType("Children's Literature");
                        CheckOut();
                        break;
                    }
                case "Science Fiction":
                    {
                        Console.Clear();
                        listView.DisplayType("Science Fiction");
                        CheckOut();
                        break;
                    }
                case "Historical Fiction":
                    {
                        Console.Clear();
                        listView.DisplayType("Historical Fiction");
                        CheckOut();
                        break;
                    }
                case "Gotchic Fiction":
                    {
                        Console.Clear();
                        listView.DisplayType("Gotchic Fiction");
                        CheckOut();
                        break;
                    }
                default:
                    break;

            }
        }
        public void DisplayAuthor()
        {
            BookListView listView = new BookListView(bookDb);
            List<string> authors= new List<string>();

            foreach(Book b in bookDb)
            {
                if(!authors.Contains(b.Author))
                {
                    authors.Add(b.Author);
                }
            }

            foreach(string author in authors)
            {
                Console.WriteLine($"\n\t{author}");
            }

            Console.WriteLine("\nBased on this list, is there an author whose books you'd like to see if we have? (y/n)");
            string response = Console.ReadLine().ToLower();

            if(response == "y")
            {
                Console.Write("Please enter your desired Author: ");
                string authorChoice = Console.ReadLine();

                foreach (Book b in bookDb)
                {
                    if (b.Author.Contains(authorChoice))
                    {
                        Console.WriteLine($"\n\t{b.Title}");
                    }

                }

                CheckOut();
            }

        }
        public void DisplayTitle()
        {
            string response = Console.ReadLine().ToLower();
            Console.WriteLine("Here are all our books that share that title:");

            foreach(Book b in bookDb)
            {
                if(b.Title.ToLower().Contains(response))
                {
                    Console.WriteLine($"\n{b.Title}");
                }
            }

            CheckOut();
        }
        public void DisplayStatus()
        {
            Console.WriteLine("\n\t1. Checked out\n\t2. Avaliable");
            string choice = Console.ReadLine();

            if(int.TryParse(choice, out int num))
            {
                switch(num)
                {
                    case 1:
                        {
                            foreach (Book b in bookDb)
                            {
                                if (b.Status == true)
                                {
                                    Console.Write($"\n\t{b.Title}");
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            foreach (Book b in bookDb)
                            {
                                if (b.Status == false)
                                {
                                    Console.Write($"\n\t{b.Title}");
                                }
                            }
                            CheckOut();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input! (Please enter a (1) or (2))\n\t(Please try again)\n");
                            DisplayStatus();
                            break;
                        }
                }
            }




        }
        public void DisplayDate()
        {
            foreach (Book b in bookDb)
            {
                if (DateTime.Compare(DateTime.Now, b.DueDate) < 0)
                {
                    Console.WriteLine($"\tTitle: {b.Title}\tDue: {(b.DueDate).ToString("MM/dd/yyyy")}");
                }
            }
            ReserveBook();
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
                        Console.WriteLine($"You have checked out: \"{b.Title}\" !");
                    }

                }
            }
            else
            {
                Console.Clear();
            }
            Console.Clear();
            WelcomeAction();
        }
        public void ReserveBook()
        {
            Console.WriteLine("Would you like to reserve a book from this selection? (y/n)");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                Console.WriteLine("Which book would you like to reserve?");
                string choice = Console.ReadLine();

                foreach (Book b in bookDb)
                {
                    if (b.Title.Contains(choice))
                    {
                        b.Status = true;
                        Console.WriteLine($"You have reserved: \"{b.Title}\" !");
                        Console.WriteLine($"It will be available for checkout on {b.DueDate}!");
                        b.DueDate.AddDays(14);
                    }

                }
            }
            else
            {
                Console.Clear();
            }
            WelcomeAction();
        }

        #endregion

        #region Validation Method
        public string isValid(int max)
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int num))
            {
                Console.Clear();
                Console.WriteLine($"{input} is not a valid option. Please choose a number from 0-7\n");
                Console.WriteLine("==================================================================");
                return isValid(max);
            }
            else if (num < 0 || num > max)
            {
                Console.Clear();
                Console.WriteLine($"{input} is not a valid option. Please choose a number from 0-7\n");
                Console.WriteLine("==================================================================");
                return isValid(max);
            }
            return input;

        }
        #endregion


    }
}
