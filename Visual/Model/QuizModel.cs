using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.Model
{
    internal class QuizModel : INotifyPropertyChanged
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

        #region ctor
        public QuizModel() { }
        public QuizModel(string nameQuiz, TimeSpan timeToComplite, int max, ObservableCollection<QuestionModel> questions, 
            ObservableCollection<string> tags, ObservableCollection<FeedbackModel> feedbacks, ObservableCollection<AnswerModel> correctAnswers) 
        { 
            _nameQuiz = nameQuiz;
            _timeToComplete = timeToComplite;
            _maxPoints = max;
            _questions = questions;
            _tags = tags;
            _feedbacks = feedbacks;
            _correctAnswers = correctAnswers;
        }


        #endregion

        #region Fields

        //private long _id { get; set; }
        private string _nameQuiz { get; set; }
        private TimeSpan _timeToComplete { get; set; }
        private int _maxPoints { get; set; }
        private ObservableCollection<QuestionModel> _questions;
        private ObservableCollection<string> _tags;

        private ObservableCollection<FeedbackModel> _feedbacks;
        private ObservableCollection<AnswerModel> _correctAnswers;


        #endregion

        #region Properties

        //public long Id
        //{
        //    get { return _id; }
        //    set
        //    {
        //        if (_id != value)
        //        {
        //            _id = value;
        //            OnPropertyChanged("Id");
        //        }
        //    }
        //}
        public string NameQuiz
        {
            get { return _nameQuiz; }
            set
            {
                if (_nameQuiz != value)
                {
                    _nameQuiz = value;
                    OnPropertyChanged("NameQuiz");
                }
            }
        }
        public TimeSpan TimeToComplete
        {
            get { return _timeToComplete; }
            set
            {
                if (_timeToComplete != value)
                {
                    _timeToComplete = value;
                    OnPropertyChanged("TimeToComplete");
                }
            }
        }

        public int MaxPoints
        {
            get { return _maxPoints; }
            set
            {
                if (_maxPoints != value)
                {
                    _maxPoints = value;
                    OnPropertyChanged("MaxPoints");
                }
            }
        }
        
        public ObservableCollection<FeedbackModel> Feedbacks
        {
            get { return _feedbacks; }
            set
            {
                if (_feedbacks != value)
                {
                    _feedbacks = value;
                    OnPropertyChanged("Feedbacks");
                }
            }
        }
        public ObservableCollection<QuestionModel> Questions
        {
            get { return _questions; }
            set
            {
                if (_questions != value)
                {
                    _questions = value;
                    OnPropertyChanged("Questions");
                }
            }
        }
        public ObservableCollection<AnswerModel> CorrectAnswers
        {
            get { return _correctAnswers; }
            set
            {
                if (_correctAnswers != value)
                {
                    _correctAnswers = value;
                    OnPropertyChanged("CorrectAnswers");
                }
            }
        }
        public ObservableCollection<string> Tags
        {
            get { return _tags; }
            set
            {
                if (_tags != value)
                {
                    _tags = value;
                    OnPropertyChanged("Tags");
                }
            }
        }

        #endregion
    }
}
