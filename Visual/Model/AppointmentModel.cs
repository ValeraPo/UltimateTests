using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.Model
{
    internal class AppointmentModel : INotifyPropertyChanged
    {
        #region Implement INotyfyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Ctor
        public AppointmentModel() { }
        public AppointmentModel(DateTime date, QuizModel quiz) 
        {
            _date = date;
            _quiz = quiz;
        }

        #endregion
        #region Fields

        private DateTime _date;

        private QuizModel _quiz;
        #endregion

        #region Properties

        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged("Text");
                }
            }
        }

        public QuizModel Quizzes
        {
            get { return _quiz; }
            set
            {
                _quiz = value;
                OnPropertyChanged("Quizzes");
            }
        }
        #endregion
    }
}
