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
                if (Dates[i] == "DateTime.Now" || DateTime.Compare(DateTime.Now.Date, DateTime.Parse(Dates[i])) > 0) //To stay dynamic with Text File in case of books being checked out.
                {
                    dueDates[i] = DateTime.Now.Date;
                }
                else
                {
                    dueDates[i] = DateTime.Parse(Dates[i]).Date;
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
            Console.WriteLine("\n\n\n");
            Console.WriteLine("{0,"+ (Console.WindowWidth/2)+"}", "Hello, welcome to the Grand Circus Library!");
            Console.WriteLine("{0," + (Console.WindowWidth / 2) + "}", "***[PLEASE MAKE FULLSCREEN]***\n\n");

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
                                DisplayBorder();
                                DisplayGenre();
                                break;
                            }
                        case 2://Author
                            {
                                DisplayBorder();
                                DisplayMenuWithBorder("Here are our list of available Authors:");
                                DisplayMenuWithBorder(" ");
                                DisplayBorder();
                                DisplayAuthor();
                                break;
                            }
                        case 3://Title
                            {
                                DisplayBorder();
                                DisplayMenuWithBorder("What is the specific Title for a book you are looking for?");
                                DisplayMenuWithBorder(" ");
                                DisplayBorder();
                                DisplayTitle();
                                break;
                            }
                        case 4://Status
                            {
                                DisplayBorder();
                                DisplayMenuWithBorder("What kind of books would you like to see:");
                                DisplayMenuWithBorder(" ");
                                DisplayBorder();
                                DisplayStatus();
                                break;
                            }
                        case 5://Upcoming returns
                            {
                                DisplayBorder();
                                DisplayMenuWithBorder("Here are books who are 'checked out',");
                                DisplayMenuWithBorder("but estimated to be returned within the next two weeks: ");
                                DisplayMenuWithBorder(" ");
                                DisplayBorder();
                                DisplayDate();
                                
                                break;
                            }
                        case 6:// All books
                            {
                                DisplayBorder();
                                DisplayMenuWithBorder("Here is our selection of ALL books: ");
                                DisplayMenuWithBorder(" ");
                                DisplayBorder();
                                DisplayAllTitle();
                                CheckOut();
                                break;
                            }
                        case 7:// Quit
                            {
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Thank you for stopping by!".Length / 2)) + (Console.WindowHeight / 2) + "}", "Thank you for stopping by!"));
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
                Console.ReadLine();
                Console.Clear();
            }
            SaveToTxtFile();
            Console.WriteLine("\nThank you!");
        }

        public void SaveToTxtFile()
        {
            string[] titles = new string[bookDb.Count];
            string[] authors = new string[bookDb.Count];
            string[] genres = new string[bookDb.Count];
            string[] dueDates = new string[bookDb.Count];
            string[] statuses = new string[bookDb.Count];

            #region Clears file
            File.Delete(@"C:\BookLibrary\Books2.txt");
            File.Delete(@"C:\BookLibrary\Genre2.txt");
            File.Delete(@"C:\BookLibrary\Author2.txt");
            File.Delete(@"C:\BookLibrary\Status2.txt");
            File.Delete(@"C:\BookLibrary\DateTime2.txt");
            #endregion

            #region Saves properties of book to declared arrays
            for (int i = 0; i < bookDb.Count; i++)
            {
                titles[i] = bookDb[i].Title;
                authors[i] = bookDb[i].Author;
                genres[i] = bookDb[i].Type;
                dueDates[i] = bookDb[i].DueDate.ToString("MM/dd/yyyy");

                if (bookDb[i].Status)
                {
                    statuses[i] = "Checked out";
                }
                else
                {
                    statuses[i] = "On the Shelf";
                }
            }
            #endregion

            #region Add indexes of those arrays to their corresponding Txt files
            File.WriteAllLines(@"C:\BookLibrary\Books2.txt", titles);
            File.WriteAllLines(@"C:\BookLibrary\Genre2.txt", genres);
            File.WriteAllLines(@"C:\BookLibrary\Author2.txt", authors);
            File.WriteAllLines(@"C:\BookLibrary\DateTime2.txt", dueDates);
            File.WriteAllLines(@"C:\BookLibrary\Status2.txt", statuses);
            #endregion
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
            string choice = Console.ReadLine().ToLower();

            switch(choice)
            {
                case "young adult":
                    {
                        Console.Clear();
                        DisplayCenterBorder();
                        listView.DisplayType("Young Adult");
                        DisplayCenterBorder();

                        CheckOut();
                        break;
                    }
                case "thriller":
                    {
                        Console.Clear();
                        DisplayCenterBorder();
                        listView.DisplayType("Thriller");
                        DisplayCenterBorder();

                        CheckOut();
                        break;
                    }
                case "satire":
                    {
                        Console.Clear();
                        DisplayCenterBorder();
                        listView.DisplayType("Satire");
                        DisplayCenterBorder();

                        CheckOut();
                        break;
                    }
                case "romantic":
                    {
                        Console.Clear();
                        DisplayCenterBorder();
                        listView.DisplayType("Romantic");
                        DisplayCenterBorder();

                        CheckOut();
                        break;
                    }
                case "fantasy":
                    {
                        Console.Clear();
                        DisplayCenterBorder();
                        listView.DisplayType("Fantasy");
                        DisplayCenterBorder();

                        CheckOut();
                        break;
                    }
                case "children's literature":
                    {
                        Console.Clear();
                        DisplayCenterBorder();
                        listView.DisplayType("Children's Literature");
                        DisplayCenterBorder();

                        CheckOut();
                        break;
                    }
                case "science fiction":
                    {
                        Console.Clear();
                        DisplayCenterBorder();
                        listView.DisplayType("Science Fiction");
                        DisplayCenterBorder();

                        CheckOut();
                        break;
                    }
                case "historical fiction":
                    {
                        Console.Clear();
                        DisplayCenterBorder();
                        listView.DisplayType("Historical Fiction");
                        DisplayCenterBorder();

                        CheckOut();
                        break;
                    }
                case "gotchic fiction":
                    {
                        Console.Clear();
                        DisplayCenterBorder();
                        listView.DisplayType("Gotchic Fiction");
                        DisplayCenterBorder();

                        CheckOut();
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid choice! Choice must be from provided selection.");
                        break;
                    }
                    

            }
        }
        public void DisplayAuthor()
        {
            int count = 0;
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
                string authorChoice = Console.ReadLine().ToLower();
                Console.Clear();
                Console.WriteLine($"Here are all our books by {authorChoice}:");

                DisplayCenterBorder();

                foreach (Book b in bookDb)
                {
                    if (b.Author.ToLower().Contains(authorChoice))
                    {
                        bControl.BookAction(b);
                    }
                    else
                    {
                        count++;
                    }
                }
                DisplayCenterBorder();

                if (count == bookDb.Count)
                {
                    Console.Clear();
                    Console.WriteLine($"Oops! Sorry, it looks like we do not have any books by \"{authorChoice}\". ");
                }
                else
                {
                    CheckOut();
                }
            }

        }
        public void DisplayTitle()
        {
            BookListView listView = new BookListView(bookDb);
            int count = 0;
            string response = Console.ReadLine();

            Console.WriteLine("Here are all our books that share that title:");

            foreach(Book b in bookDb)
            {
                if(b.Title.ToLower().Contains(response.ToLower()))
                {
                    listView.DisplayTitle(b.Title);
                }
                else
                {
                    count++;
                }
            }
            if (count == bookDb.Count)
            {
                Console.Clear();
                Console.WriteLine($"Oops! Sorry, it looks like we could not find \"{response}\" in our records of books");
            }
            else
            {
                CheckOut();
            }
        }
        public void DisplayAllTitle()
        {
            BookListView listView = new BookListView(bookDb);

            foreach (Book b in bookDb)
            {
                    listView.DisplayTitle(b.Title);
            }
        }
        public void DisplayStatus()
        {
           // Console.WriteLine("\n\t1. Checked out\n\t2. Avaliable");
            Console.WriteLine("{0," + (Console.WindowWidth / 2) +"}"," 1. Checked out");
            Console.WriteLine("{0," + (Console.WindowWidth / 2) +"}","2. Avaliable");


            Console.Write("{0," + (Console.WindowWidth / 2) + "}", "(1 / 2): ");
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
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input! (Please enter a (1) or (2))\n\t(Please try again)\n");
                DisplayStatus();
            }




        }
        public void DisplayDate()
        {
            foreach (Book b in bookDb)
            {
                BookView view = new BookView(b);

                if (DateTime.Compare(DateTime.Now, b.DueDate) < 0)
                {
                    view.DisplayDate();
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
                int count = 0;
                Console.WriteLine("Which book would you like to check out?");
                string choice = Console.ReadLine();

                foreach (Book b in bookDb)
                {
                    if (b.Title == choice)
                    {
                        if (b.Status == true)
                        {
                            Console.Write($"\nSorry, \"{b.Title}\" is currently already checked out till {b.DueDate.ToString("MM/dd/yyyy")}.\nWould you like to reserve a copy and pick it up when it becomes available? (y/n): ");
                            string reserveChoice = Console.ReadLine().ToLower();

                            if(reserveChoice == "y")
                            {
                                b.Status = true;
                                Console.WriteLine($"You have reserved: \"{b.Title}\" !");
                                Console.WriteLine($"It will be available for checkout on {b.DueDate.ToString("MM/dd/yyyy")}!");
                                b.DueDate = b.DueDate.AddDays(14);
                                
                                Console.WriteLine($"{b.Title} will due back by: {b.DueDate.ToString("MM/dd/yyyy")}");
                            }
                        }
                        else
                        {
                            b.Status = true;
                            Console.WriteLine($"You have checked out: \"{b.Title}\" !");
                            b.DueDate = b.DueDate.AddDays(14);
                            Console.WriteLine($"{b.Title} will be due back by: {b.DueDate.ToString("MM/dd/yyyy")}");
                        }
                    }
                    else
                    {
                        count++;
                    }

                }
                if (count == BookDb.Count)
                {
                    Console.WriteLine($"Sorry, {choice} is not part of this list!\n");
                }

            }
            else
            {
                Console.Clear();
            }
        }
        public string RemoveApostrophe(string s)
        {
            int apostrophe = s.IndexOf('\'');

            string before = s.Substring(0, apostrophe + 1);
            string after = s.Substring((apostrophe + 1));
            string normalized = before + after;

            return normalized;
        }//Not Necessary
        public void ReserveBook()
        {
            int count = 0;
            Console.Write("\n\nWould you like to reserve a book from this selection? (y/n): ");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                Console.WriteLine("Which book would you like to reserve?");
                string choice = Console.ReadLine();

                foreach (Book b in bookDb)
                {
                    if (b.Title.ToLower().Contains(choice.ToLower()))
                    {
                        b.Status = true;
                        Console.WriteLine($"You have reserved: \"{b.Title}\" !");
                        Console.WriteLine($"It will be available for checkout on {b.DueDate.ToString("MM/dd/yyyy")}!");
                        b.DueDate.AddDays(14);
                    }
                    else
                    {
                        count++;
                    }
                }
                if(count == BookDb.Count)
                {
                    Console.WriteLine($"Sorry, {choice} is not part of this list!\n");
                }
            }
            else
            {
                Console.Clear();
                
            }
        }

        #endregion

        


    }
}
