using System;
using System.Collections.ObjectModel;
using System.Linq;
using Data.Interfaces;
using Data.Maps;
using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;

namespace Logic.Processes
{
    public class Quizze : IQuizze
    {
        private IRepository<Data.Maps.Quizze> _quizzes;
        private IRepository<Data.Maps.Group>  _groups;
        private IRepository<Data.Maps.User>   _users;
        public Quizze()
        {
            _quizzes = IocKernel.Get<IRepository<Data.Maps.Quizze>>();
            _groups  = IocKernel.Get<IRepository<Data.Maps.Group>>();
            _users   = IocKernel.Get<IRepository<Data.Maps.User>>();
        }

        //отдаст класс дто со всеми полями с коллекциями (в конструктор формы)
        public QuizzeDTO GetEntity(long id)
        {
            return new QuizzeDTO(_quizzes.GetEntity(id), true);
        }
        
        public QuizzeDTO GetEntityNotNested(long id)
        {
            return new QuizzeDTO(_quizzes.GetEntity(id));
        }
        public QuizzeDTO GetEntityNotNested(string name)
        {
            return new QuizzeDTO(_quizzes.GetListEntity().Single(t => t.Name == name));
        }
        public ObservableCollection<QuizzeDTO> GetListEntity()
        {
            var quizzes = new ObservableCollection<QuizzeDTO>();
            foreach (var quiz in _quizzes.GetListEntity())
                quizzes.Add(new QuizzeDTO(quiz));

            return quizzes;
        }
        // Добавление нового Quiz из DTO версии + подсчёт MaxPoints
        //TODO протестить
        public void AddQuiz(QuizzeDTO quiz, UserDTO user)
        {
            if (_quizzes.GetListEntity()
                     .Select(t => t.Name)
                     .Contains(quiz.NameQuiz))
                throw new ArgumentException("Тест с таким именем уже существует");
            var quizMap = new Data.Maps.Quizze
                          {
                              Name           = quiz.NameQuiz,
                              MaxPoints      = 0,
                              TimeToComplete = quiz.TimeToComplete,
                              User           = _users.GetEntity(user.Id)
                          };

            foreach (var question in quiz.Questions)
            {
                var questionMap = new Question
                                  {
                                      Text         = question.Text,
                                      ID_QuestType = question.ID_QuestType
                                  };
                foreach (var answer in question.Answers)
                {
                    var answerMap = new Answer
                                    {
                                        Text      = answer.Text,
                                        IsCorrect = answer.IsCorrect
                                    };
                    questionMap.Answers.Add(answerMap);
                    if (answer.IsCorrect)
                        quizMap.MaxPoints++;
                }

                quizMap.Questions.Add(questionMap);
            }

            _quizzes.Create(quizMap);
            SaveChange();
        }
        
        //Выборка попыток
        public ObservableCollection<AttemptDTO> GetListAttempt(QuizzeDTO quiz)
        {
            var res = new ObservableCollection<AttemptDTO>();
            foreach (var attempt in _quizzes.GetEntity(quiz.Id).Attempts)
                res.Add(new AttemptDTO(attempt));

            return res;
        }

        //Добавить тег тесту
        public void AddTag(QuizzeDTO quizze, SetTagDTO teg)
        {
            var myQuizze = _quizzes.GetEntity(quizze.Id);
            if (myQuizze.QuizzesCategories.All(t => t.ID_TagSet != teg.Id))
            {
                myQuizze.QuizzesCategories.Add(new QuizzesCategory
                {
                                                               ID_Quiz   = quizze.Id,
                                                               ID_TagSet = teg.Id
                                                           });
            }
            else
                myQuizze.QuizzesCategories.Single(t => t.ID_TagSet == teg.Id).IsDel = false;

            SaveChange();
        }
        // Текущие теги у Quiz
        public ObservableCollection<SetTagDTO> GetListTags(QuizzeDTO quiz)
        {
            var res = new ObservableCollection<SetTagDTO>();
            foreach (var teg in _quizzes.GetEntity(quiz.Id).QuizzesCategories.Select(t => t.SetTag))
                res.Add(new SetTagDTO(teg));

            return res;
        }

        // Удаление теста
        public void RemoveQuizze(QuizzeDTO quizze)
        {
            _quizzes.Delete(quizze.Id);
        }
        public void RemoveQuizze(string nameQuiz)
        {
            _quizzes.Delete(_quizzes.GetListEntity().Single(t=> t.Name == nameQuiz).ID_Quiz);
        }
        /*
        // Проверка правильности ответа
        public static void CheckAnswer(Answer answer, Attempt attempt, Quizze quiz)
        {
            if (answer.IsCorrect)
                attempt.Score += quiz.MaxPoints / quiz.Questions.Count;
        }
        */

        // Добавить назначение по группе
        public void AddAppointmentQuizze(QuizzeDTO quizze, GroupDTO group, DateTime finishBefore)
        {
            var myQuiz  = _quizzes.GetEntity(quizze.Id);
            var myGroup = _groups.GetEntity(group.Id);

            foreach (var person in myGroup.Users)
            {
                myQuiz.AppointmentQuizzes.Add(new Data.Maps.AppointmentQuizze
                {
                                                  FinishBefore = finishBefore,
                                                  User         = person,
                                                  ID_Quiz      = quizze.Id
                                              });
            }

            SaveChange();
        }
        // Добавить назначение по человеку
        public void AddAppointmentQuizzeUser(QuizzeDTO quizze, UserDTO user, DateTime finishBefore)
        {
            var myQuiz  = _quizzes.GetEntity(quizze.Id);
            var student = _users.GetEntity(user.Id);


            myQuiz.AppointmentQuizzes.Add(new Data.Maps.AppointmentQuizze
            {
                                              FinishBefore = finishBefore,
                                              User         = student,
                                              ID_Quiz      = quizze.Id
                                          });

            SaveChange();
        }

        // Создание фидбека
        public void AddFeedback(QuizzeDTO quiz, string text, UserDTO user)
        {
            var myQuiz = _quizzes.GetEntity(quiz.Id);
            myQuiz.Feedbacks.Add(new Data.Maps.Feedback
            {
                                     DateTime = DateTime.Now,
                                     ID_Quiz  = quiz.Id,
                                     ID_User  = user.Id,
                                     Text     = text
                                 });
            SaveChange();
        }

        // Показать фидбеки к тесту методиста
        public ObservableCollection<FeedbackDTO> GetFeedback(QuizzeDTO quiz)
        {
            var feedbacks = new ObservableCollection<FeedbackDTO>();
            foreach (var feedback in _quizzes.GetEntity(quiz.Id).Feedbacks)
                feedbacks.Add(new FeedbackDTO(feedback));

            return feedbacks;
        }
        // Сохранить изменения
        public void SaveChange() => _users.Save();
        // Обновление модели (пересоздании зависимостей EF)
        public void Refresh() => _users.Refresh();
        //Сохранение изменения
        public void Update(QuizzeDTO quiz)
        {
            var tmp = _quizzes.GetEntity(quiz.Id);
            tmp.MaxPoints      = quiz.MaxPoints;
            tmp.Name           = quiz.NameQuiz;
            tmp.TimeToComplete = quiz.TimeToComplete;
            foreach (var question in quiz.Questions)
                UpdateQuestion(question, tmp.Questions.Single(t => t.ID_Quest == question.Id));


            _quizzes.Update(tmp);

            SaveChange();
        }
        public void UpdateQuestion(QuestionDTO questionDto, Question question)
        {
            question.Text         = questionDto.Text;
            question.ID_QuestType = questionDto.ID_QuestType;
            foreach (var answer in questionDto.Answers)
                UpdateAnswer(answer, question.Answers.Single(t => t.ID_Answ == answer.Id));
        }
        public void UpdateAnswer(AnswerDTO answerDto, Answer answer)
        {
            answer.Text      = answerDto.Text;
            answer.IsCorrect = answerDto.IsCorrect;
        }
    }
}