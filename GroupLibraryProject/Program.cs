using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupLibraryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            

            #region From Txt file to string Array
            string[] Titles = File.ReadAllLines(@"C:\BookLibrary\Books.txt");
            string[] Authors = File.ReadAllLines(@"C:\BookLibrary\Author.txt");
            string[] Types = File.ReadAllLines(@"C:\BookLibrary\Genre.txt");
            #endregion

            #region From Txt file to DateTime Array
            string[] Dates = File.ReadAllLines(@"C:\BookLibrary\DateTime.txt");
            DateTime[] dueDates = new DateTime[Dates.Length];
            for(int i = 0; i <Dates.Length;i++)
            {
                if (Dates[i] == "DateTime.Now")
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
                if(checkedOut[i] == "On the shelf")
                {
                    statuses[i] = false;
                }
                else
                {
                    statuses[i] = true;
                }
            }
            #endregion

            List<Book> bookDb = new List<Book>();

            Console.WriteLine($"{Titles.Length}\n{Authors.Length}\n{Types.Length}\n{Dates.Length}\n{checkedOut.Length}\n");


            for(int i=0; i< Titles.Length;i++)
            {
                bookDb[i].Title = Titles[i];
                bookDb[i].Author = Authors[i];
                bookDb[i].Type = Types[i];
                bookDb[i].DueDate = dueDates[i];
                bookDb[i].Status = statuses[i];
            }

            BookListView listView = new BookListView(bookDb);
            BookController Control = new BookController(listView);



            Control.WelcomeAction();



        }
    }
}
