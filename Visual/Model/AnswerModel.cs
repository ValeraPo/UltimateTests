using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.Model
{
    internal class AnswerModel : INotifyPropertyChanged
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
        public AnswerModel() { }
        public AnswerModel(string text, bool isCorrect)
        {
            _text = text;
            _isCorrect = IsCorrect;
        }
        #endregion

        #region Fields

        //private string _type;
        private string _text;
        private string _isCorrect;

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
        //public string Type
        //{
        //    get { return _type; }
        //    set
        //    {
        //        if (_type != value)
        //        {
        //            _type = value;
        //            OnPropertyChanged("Type");
        //        }
        //    }
        //}
        public string IsCorrect
        {
            get { return _isCorrect; }
            set
            {
                if (_isCorrect != value)
                {
                    _isCorrect = value;
                    OnPropertyChanged("IsCorrect");
                }
            }
        }

        #endregion
    }
}
