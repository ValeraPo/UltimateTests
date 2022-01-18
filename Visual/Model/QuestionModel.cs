using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.Model
{
    internal class QuestionModel : INotifyPropertyChanged
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
        public QuestionModel() { }
        public QuestionModel(int questType, string text, ObservableCollection<AnswerModel> answers) 
        {
            _questType = questType;
            _text = text;
            _answers = answers;
        }

        #endregion

        #region Fields


        private int _questType;
        private string _text;
        private ObservableCollection<AnswerModel> _answers;


        #endregion

        #region Properties

        public int QuestType
        {
            get { return _questType; }
            set
            {
                if (_questType != value)
                {
                    _questType = value;
                    OnPropertyChanged("QuestType");
                }
            }
        }
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
        public ObservableCollection<AnswerModel> Answers
        {
            get { return _answers; }
            set
            {
                _answers = value;
                OnPropertyChanged("Answers");
            }
        }
        

        #endregion
    }
}
