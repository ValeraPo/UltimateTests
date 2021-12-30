using System;
using System.Collections.ObjectModel;

namespace Logic.DTO
{
    public class QuizzeDTO
    {
        public QuizzeDTO(long id, string nameQuiz, TimeSpan timeToComplete, int maxPoints, ObservableCollection<QuestionDTO> questions)
        {
            Id = id;
            NameQuiz = nameQuiz;
            TimeToComplete = timeToComplete;
            MaxPoints = maxPoints;
            Questions = questions;
        }
        public QuizzeDTO(Data.Maps.Quizze quiz, bool flag)
        {
            Id             = quiz.ID_Quiz;
            NameQuiz       = quiz.Name;
            TimeToComplete = quiz.TimeToComplete;
            MaxPoints      = quiz.MaxPoints;
            Questions      = new ObservableCollection<QuestionDTO>();
            if (!flag)
                return;
            foreach (var question in quiz.Questions)
                Questions.Add(new QuestionDTO(question));
        }
        
        
        public long                              Id             {get; set;}
        public string                            NameQuiz       {get; set;}
        public TimeSpan                          TimeToComplete {get; set;}
        public int                               MaxPoints      {get; set;}
        public ObservableCollection<QuestionDTO> Questions      {get; set;}
    }
}