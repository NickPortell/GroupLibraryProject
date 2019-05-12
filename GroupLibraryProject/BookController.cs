using System;
using System.Collections.Generic;
using System.IO;
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
        public BookController()//BookListView _listView)
        {
            //listView = _listView;
            bookDb = new List<Book>();

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
            #region From Txt file to string Array
            string[] Titles = File.ReadAllLines(@"C:\BookLibrary\Books.txt");
            string[] Authors = File.ReadAllLines(@"C:\BookLibrary\Author.txt");
            string[] Types = File.ReadAllLines(@"C:\BookLibrary\Genre.txt");
            #endregion

            #region From Txt file to DateTime Array
            string[] Dates = File.ReadAllLines(@"C:\BookLibrary\DateTime.txt");
            DateTime[] dueDates = new DateTime[Dates.Length];
            for (int i = 0; i < Dates.Length; i++)
            {
                if (Dates[i] == "DateTime.Now" || DateTime.Compare(DateTime.Now, DateTime.Parse(Dates[i])) > 0) //To stay dynamic with Text File in case of books being checked out.
                {
                    dueDates[i] = DateTime.Now;
                }
                else
                {
                    dueDates[i] = DateTime.Parse(Dates[i]);
                }
            }
            #endregion

            #region From Txt file to bool Array
            string[] checkedOut = File.ReadAllLines(@"C:\BookLibrary\Status.txt");
            bool[] statuses = new bool[checkedOut.Length];
            for (int i = 0; i < Dates.Length; i++)
            {
                if (checkedOut[i] == "On the shelf")
                {
                    statuses[i] = false;
                }
                else
                {
                    statuses[i] = true;
                }
            }
            #endregion


            for (int i = 0; i < Titles.Length; i++)
            {
                Book book = new Book(Titles[i], Authors[i], dueDates[i], Types[i], statuses[i]);

                bookDb.Add(book);
            }


            BookListView listView = new BookListView(bookDb);
            Console.WriteLine("Hello, welcome to the Grand Circus Library!");
            Console.WriteLine("***[PLEASE MAKE FULLSCREEN]***\n\n");

            while (response == "yes")
            {
                //Maybe prompt a rotating selection of 'popular' books as a 'book of the day or hotest author'.
                DisplayBorder();
                DisplayMenuWithBorder("\tHere are some browsing/search options:");
                DisplayMenuWithBorder("\t ");
                DisplayMenuWithBorder("\t1. By Genre");
                DisplayMenuWithBorder("\t2. By Author");
                DisplayMenuWithBorder("\t3. By Specific Title");
                DisplayMenuWithBorder("\t4. By Checkout Status");
                DisplayMenuWithBorder("\t5. Expected Returns");
                DisplayMenuWithBorder("\t6. All Books");
                DisplayMenuWithBorder("\t7. Quit");
                DisplayBorder();

                Console.Write("\nMENU OPTION: ");
                string choice = Console.ReadLine();
                Console.Clear();

                if (int.TryParse(choice, out int num))
                {
                    switch (num)
                    {
                        case 1://Genre
                            {
                                DisplayBorder();
                                DisplayMenuWithBorder("Here are our available types of books:");
                                DisplayMenuWithBorder(" ");
                                DisplayGenre();
                                break;
                            }
                        case 2://Author
                            {
                                DisplayBorder();
                                DisplayMenuWithBorder("Here are our list of available Authors:");
                                DisplayMenuWithBorder(" ");
                                DisplayAuthor();
                                break;
                            }
                        case 3://Title
                            {
                                DisplayBorder();
                                DisplayMenuWithBorder("What is the specific Title for a book you are looking for?");
                                DisplayMenuWithBorder(" ");
                                DisplayTitle();
                                break;
                            }
                        case 4://Status
                            {
                                DisplayBorder();
                                DisplayMenuWithBorder("What kind of books would you like to see:");
                                DisplayMenuWithBorder(" ");
                                DisplayStatus();
                                break;
                            }
                        case 5://Upcoming returns
                            {
                                DisplayBorder();
                                DisplayMenuWithBorder("Here are books who are 'checked out', but estimated to be returned within the next two weeks: ");
                                DisplayMenuWithBorder(" ");
                                DisplayDate();
                                break;
                            }
                        case 6:// All books
                            {
                                DisplayBorder();
                                DisplayMenuWithBorder("Here is our selection of ALL books in alphabetical order: ");
                                DisplayMenuWithBorder(" ");
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
                                break;
                            }
                            
                    }
                }
                else
                {
                    Console.WriteLine("invalid input! Please enter a valid number between 1-7 \n\t(Please try again)");
                }
                //Console.Clear();
            }
            Console.WriteLine("\nThank you!");
        }


        public void DisplayGenre()
        {
            BookListView listView = new BookListView(bookDb);

            DisplayMenuWithBorder("Young Adult");
            DisplayMenuWithBorder("Thriller");
            DisplayMenuWithBorder("Satire");
            DisplayMenuWithBorder("Romantic");
            DisplayMenuWithBorder("Fantasy");
            DisplayMenuWithBorder("Children's Literature");
            DisplayMenuWithBorder("Science Fiction");
            DisplayMenuWithBorder("Historical Fiction");
            DisplayMenuWithBorder("Gothic Fiction");
            DisplayBorder();

            Console.WriteLine("\nWhich type would like to see a list of?");
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
            BookController bControl = new BookController();
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
                DisplayMenuWithBorder(author);
            }
            DisplayBorder();

            Console.Write("\nBased on this list, is there an author whose books you'd like to see if we have? (y/n): ");
            string response = Console.ReadLine().ToLower();

            if(response == "y")
            {
                Console.Write("Please enter your desired Author: ");
                string authorChoice = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Here are all our books by {authorChoice}:");

                DisplayCenterBorder();
                foreach (Book b in bookDb)
                {
                    if (b.Author.Contains(authorChoice))
                    {

                        bControl.BookAction(b);
                    }

                }
                DisplayCenterBorder();

                
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

            Console.Write("(1 / 2): ");
            string choice = Console.ReadLine();


            if(int.TryParse(choice, out int num))
            {
                Console.Clear();

                switch (num)
                {
                    case 1:
                        {
                            DisplayBorder();

                            foreach (Book b in bookDb)
                            {
                                if (b.Status == true)
                                {
                                    DisplayTitleWithBorder(b);              
                                }
                            }
                            DisplayBorder();

                            ReserveBook();
                            break;
                        }
                    case 2:
                        {
                            DisplayBorder();

                            foreach (Book b in bookDb)
                            {
                                if (b.Status == false)
                                {
                                    DisplayTitleWithBorder(b);
                                }
                            }
                            DisplayBorder();

                            CheckOut();
                            break;
                        }
                    default:
                        {
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

        public int MaxTitleLength()
        {
            int max = 0;
            foreach(Book b in bookDb)
            {
                if(max < b.Title.Length)
                {
                    max = b.Title.Length;
                }    
            }
            return max;
        }

        public void DisplayBorder()
        {
            string border = "";

            for (int i = 0; i < MaxTitleLength(); i++)
            {
                border += "=";
            }
            Console.WriteLine("{0," +MaxTitleLength() +"}{1," + MaxTitleLength() + "}"," " ,border);
        }
        public void DisplayCenterBorder()
        {
            string border = "";

            for (int i = 0; i < MaxTitleLength(); i++)
            {
                border += "=";
            }
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (border.Length / 2)) + "}", border));
        }
        public void DisplayMenuWithBorder(string s)
        {
            string prompt = string.Format("{0," + (MaxTitleLength()) + "}{1," + (-MaxTitleLength()) + "}", "|| ", s);

            Console.Write(prompt);

            Console.WriteLine("{0," + (-MaxTitleLength()) + "}", " ||");
        }
        public void DisplayTitleWithBorder(Book b)
        {
                string prompt = string.Format("{0," + (MaxTitleLength()) + "}{1," + (-MaxTitleLength()) + "}", "|| ", b.Title);

                Console.Write(prompt);

                Console.WriteLine("{0," + (-MaxTitleLength()) + "}", " ||");
        }

        public void CheckOut()
        {
            Console.Write("\n\nWould you like to check out a book from this selection? (y/n): ");
            string response = Console.ReadLine().ToLower();

            if (response == "y")
            {
                Console.WriteLine("Which book would you like to check out?");
                string choice = Console.ReadLine();

                foreach (Book b in bookDb)
                {
                    if (b.Title.ToLower().Trim() == choice.ToLower().Trim())
                    {
                        if (b.Status == true)
                        {
                            Console.Write($"Sorry, \"{b.Title}\" is currently already checked out till {b.DueDate}.\nWould you like to reserve a copy and pick it up when it becomes available? (y/n): ");
                            string reserveChoice = Console.ReadLine().ToLower();

                            if(reserveChoice == "y")
                            {
                                b.Status = true;
                                Console.WriteLine($"You have reserved: \"{b.Title}\" !");
                                Console.WriteLine($"It will be available for checkout on {b.DueDate}!");
                                b.DueDate.AddDays(14);
                            }
                        }
                        else
                        {
                            b.Status = true;
                            Console.WriteLine($"You have checked out: \"{b.Title}\" !");
                            b.DueDate.AddDays(14);
                            Console.WriteLine($"It will be do back by: {b.DueDate}");
                        }
                    }

                }
            }
            else
            {
                Console.Clear();
            }
        }
        public void ReserveBook()
        {
            Console.Write("\n\nWould you like to reserve a book from this selection? (y/n): ");
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
