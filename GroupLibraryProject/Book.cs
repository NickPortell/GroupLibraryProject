
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupLibraryProject
{
    class Book
    {
        #region Fields
        private string title;
        private string author;
        private DateTime dueDate;
        private string type;
        private bool status;
        #endregion

        #region Properties
        public string Title
        {
            set { title = value; }
            get { return title; }
        }
        public string Author
        {
            set { author = value; }
            get { return author; }
        }
        public DateTime DueDate
        {
            set { dueDate = value; }
            get { return dueDate; }
        } 
        public string Type
        {
            set { type = value; }
            get { return type; }
        }
        public bool Status
        {
            set { status = value; }
            get { return status; }
        }
        #endregion

        #region Constructor
        public Book(string _title, string _author, DateTime _dueDate, string _type, bool _status)
        {
            title = _title;
            author = _author;
            dueDate = _dueDate;
            type = _type;
            status = _status;
        }
        #endregion
    }

}

