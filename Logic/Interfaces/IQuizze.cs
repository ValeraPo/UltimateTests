using System;
using System.Collections.ObjectModel;
using Data.Maps;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IQuizze
    {
        public QuizzeDTO GetEntity(long id);
        public QuizzeDTO GetEntityNotNested(long id);
        public QuizzeDTO GetEntityNotNested(string name);
        public ObservableCollection<QuizzeDTO> GetListEntity();
        public void AddQuiz(QuizzeDTO quiz, UserDTO user);
        public ObservableCollection<AttemptDTO> GetListAttempt(QuizzeDTO quiz);
        public void AddTag(QuizzeDTO quizze, SetTagDTO teg);
        public ObservableCollection<SetTagDTO> GetListTags(QuizzeDTO quiz);
        public void RemoveQuizze(QuizzeDTO quizze);
        public void RemoveQuizze(string nameQuiz);
        public void AddAppointmentQuizze(QuizzeDTO quizze, GroupDTO group, DateTime finishBefore);
        public void AddAppointmentQuizzeUser(QuizzeDTO quizze, UserDTO user, DateTime finishBefore);
        public void AddFeedback(QuizzeDTO quiz, string text, UserDTO user);
        public ObservableCollection<FeedbackDTO> GetFeedback(QuizzeDTO quiz);
        public void SaveChange();
        public void Refresh();
        public void Update(QuizzeDTO quiz);
        public void UpdateQuestion(QuestionDTO questionDto, Question question);
        public void UpdateAnswer(AnswerDTO answerDto, Answer answer);
    }
}