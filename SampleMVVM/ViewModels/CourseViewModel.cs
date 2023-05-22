using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleMVVM.Models;
using SampleMVVM.Commands;
using System.Windows.Input;

namespace SampleMVVM.ViewModels
{
    class CourseViewModel : ViewModelBase
    {
        public Course Course;

        public CourseViewModel(Course Course)
        {
            this.Course = Course;
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
        }

        private bool CanGiveItem()
        {
            return Amount > 0;
        }

        #endregion

        #endregion
    }
}
