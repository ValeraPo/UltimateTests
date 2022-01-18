using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.Model
{
    internal class FeedbackModel : INotifyPropertyChanged
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

        public FeedbackModel() { }
        public FeedbackModel(DateTime date, string userName, string text) 
        {
            _date = date;
            _text = text;
            _userName = userName;
        }


        #endregion

        #region Fields

        private DateTime _date;
        private string _text;
        private string _userName;

        #endregion

        #region Properties

        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged("Text");
                }
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        #endregion
    }
}
