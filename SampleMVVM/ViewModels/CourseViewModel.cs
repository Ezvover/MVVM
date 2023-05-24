using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleMVVM.Models;
using SampleMVVM.Commands;
using System.Windows.Input;
using System.Data.SqlClient;

namespace SampleMVVM.ViewModels
{
    class CourseViewModel : ViewModelBase
    {
        public Course Course;

        public CourseViewModel(Course Course)
        {
            this.Course = Course;
        }

        public int Id
        {
            get { return Course.Id; }
            set
            {
                Course.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return Course.Name; }
            set 
            {
                Course.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Author
        {
            get { return Course.Author; }
            set
            {
                Course.Author = value;
                OnPropertyChanged("Author");
            }
        }

        public int Amount
        {
            get { return Course.Amount; }
            set
            {
                Course.Amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public int Hours
        {
            get { return Course.Hours; }
            set
            {
                Course.Hours = value;
                OnPropertyChanged("Hours");
            }
        }

        public void Update()
        {
            string connectionString = @"Data Source=.;Initial Catalog=Courses;Integrated Security=True";
            string updateQuery = $"UPDATE Course SET amount = {Amount} WHERE id = {Id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@amount", Amount);
                    command.ExecuteNonQuery();
                }
            }
        }

        #region Commands

        #region Забрать

        private DelegateCommand getItemCommand;

        public ICommand GetItemCommand
        {
            get
            {
                if (getItemCommand == null)
                {
                    getItemCommand = new DelegateCommand(GetItem);
                }
                return getItemCommand;
            }
        }

        private void GetItem()
        {
            Amount++;
            Update();
        }

        #endregion

        #region Выдать

        private DelegateCommand giveItemCommand;

        public ICommand GiveItemCommand
        {
            get
            {
                if (giveItemCommand == null)
                {
                    giveItemCommand = new DelegateCommand(GiveItem, CanGiveItem);
                }
                return giveItemCommand;
            }
        }

        private void GiveItem()
        {
            Amount--;
            Update();
        }

        private bool CanGiveItem()
        {
            return Amount > 0;
        }

        #endregion

        #endregion
    }
}
