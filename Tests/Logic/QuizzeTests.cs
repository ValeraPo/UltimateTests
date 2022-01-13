using System;
using System.Collections.ObjectModel;
using System.Linq;
using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;
using NUnit.Framework;

namespace Tests.Logic
{
    [TestFixture]
    public class QuizzeTests
    {
        private IQuizze _quiz = IocKernel.Get<IQuizze>();
        //
        // Добавить тест
        [TestCase("test1", 6, 1,0,0)]
        [TestCase("test2", 6, 1,30,0)]
        [TestCase("test3", 6, 0,0,30)]
        [TestCase("test4", 7, 0,1,0)]
        [TestCase("test5", 7, 1,30,30)]
        public void AddAQuizTest(string nameQuiz, long idUser, byte hour, byte min, byte sec)
        {
            var tmp = new TimeSpan(hour,min,sec);
            var newQuiz = new QuizzeDTO(nameQuiz, tmp, new ObservableCollection<QuestionDTO>());
            var user = IocKernel.Get<IUser>().GetEntity(idUser);
            _quiz.AddQuiz(newQuiz, user);
            
            CollectionAssert.Contains(_quiz.GetListEntity().Select(t =>t.NameQuiz).ToList(), nameQuiz);
        }
        //
        // Добавить тег тесту
        public void AddTagTest(string nameQuize, long idTag)
        {
            // Создаем DTO классы теста и тега
            var quiz = _quiz.GetEntityNotNested(nameQuize);
            var tag = IocKernel.Get<ISetTag>().GetEntity(idTag);
            //Запускаем тестируемый метод
            _quiz.AddTag(quiz, tag);
            var tags = new ObservableCollection<SetTagDTO>();
            tags.Add(tag);
            // Вытаскиваем из БД групы по тегу          
            var expexted = IocKernel.Get<ISetTag>().SearchQuizzesByTeg(tags).Select(t =>t.NameQuiz);
            
            CollectionAssert.Contains(expexted, quiz.NameQuiz);
        }
        //
        // Создание фидбека
        [TestCase("test1", "test1", 5)]
        [TestCase("test2", "test2", 4)]
        [TestCase("test3", "test3", 3)]
        [TestCase("test4", "test4", 2)]
        [TestCase("test5", "test5", 1)]
        public void AddFeedbackTest(string nameQuize, string text, long idUser) 
            //(QuizzeDTO quiz, string text, UserDTO user)
        {
            // Создаем DTO классы теста и юзера
            var quiz = _quiz.GetEntityNotNested(nameQuize);
            var user = IocKernel.Get<IUser>().GetEntity(idUser);
            //Запускаем тестируемый метод
            _quiz.AddFeedback(quiz, text, user);
            // Вытаскиваем список фидбеков этого теста
            var expexted = _quiz.GetFeedback(quiz).Select(t => t.Text);
            
            CollectionAssert.Contains(expexted, text);

        }
        
        
        //
        // Удалить тест
        [TestCase("test1")]
        [TestCase("test2")]
        [TestCase("test3")]
        [TestCase("test4")]
        [TestCase("test5")]
        public void RemoveQuizzeTest(string nameQuiz)
        {
            _quiz.RemoveQuizze(nameQuiz);
            CollectionAssert.DoesNotContain(_quiz.GetListEntity().Select(t =>t.NameQuiz).ToList(), nameQuiz);
        }

    }
}