using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Logic.DTO
{
    public class QuizzeDTO : AbstractOnPropertyChanged
    {
        private string                            _nameQuiz;
        private TimeSpan                          _timeToComplete;
        private int                               _maxPoints;
        private ObservableCollection<QuestionDTO> _questions;


        public QuizzeDTO(long id, string nameQuiz, TimeSpan timeToComplete, int maxPoints, ObservableCollection<QuestionDTO> questions)
        {
            Id             = id;
            NameQuiz       = nameQuiz;
            TimeToComplete = timeToComplete;
            MaxPoints      = maxPoints;
            Questions      = questions;
        }
        public QuizzeDTO(string nameQuiz, TimeSpan timeToComplete, ObservableCollection<QuestionDTO> questions)
        {
            NameQuiz       = nameQuiz;
            TimeToComplete = timeToComplete;
            Questions      = questions;
        }
        public QuizzeDTO(string nameQuiz, TimeSpan timeToComplete)
            : this(nameQuiz, timeToComplete, new ObservableCollection<QuestionDTO>()) { }
        public QuizzeDTO(Data.Maps.Quizze quiz, bool flag = false)
        {
            Id             = quiz.ID_Quiz;
            NameQuiz       = quiz.Name;
            TimeToComplete = quiz.TimeToComplete;
            MaxPoints      = quiz.MaxPoints;
            Questions      = new ObservableCollection<QuestionDTO>();
            if (!flag)
                return;
            foreach (var question in quiz.Questions.Where(t => !t.IsDel))
                Questions.Add(new QuestionDTO(question));
        }


        public long Id {get; set;}
        public string NameQuiz
        {
            get => _nameQuiz;
            set
            { if (_nameQuiz == value)
                  return;
              _nameQuiz = value;
              OnPropertyChanged(nameof(NameQuiz)); }
        }
        public TimeSpan TimeToComplete
        {
            get => _timeToComplete;
            set
            { if (_timeToComplete == value)
                  return;
              _timeToComplete = value;
              OnPropertyChanged(nameof(TimeToComplete)); }
        }
        public int MaxPoints
        {
            get => _maxPoints;
            set
            { if (_maxPoints == value)
                  return;
              _maxPoints = value;
              OnPropertyChanged(nameof(MaxPoints)); }
        }
        public ObservableCollection<QuestionDTO> Questions
        {
            get => _questions;
            set
            { if (_questions == value)
                  return;
              _questions = value;
              OnPropertyChanged(nameof(Questions)); }
        }
    }
}