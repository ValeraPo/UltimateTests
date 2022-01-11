using System;
using System.Collections.ObjectModel;
using System.Linq;
using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;
using Logic.Processes;
using NUnit.Framework;
namespace Tests
{
    [TestFixture]
    public class SetTagTest
    {
        private ISetTag _feedback = IocKernel.Get<ISetTag>();
        //
        // Возврат групп по тегу
        [TestCase(2, 1)]
        [TestCase(3, 4)]
        [TestCase(1, 2)]
        public void SearchGroupByTegTest(long idGroup, long idTag)
        {
            var tags = new ObservableCollection<SetTagDTO>();
            tags.Add(_feedback.GetEntity(idTag));
            var group = IocKernel.Get<IGroup>().GetEntity(idGroup);
            var ecpected = _feedback.SearchGroupByTeg(tags);
            CollectionAssert.Contains(ecpected, group);

        }
        //
        // Возврат тестов по тегу
        [TestCase(1, 17)]
        public void SearchQuizzeTegTest(long idQuizze, long idTag)
        {
            var tags = new ObservableCollection<SetTagDTO>();
            tags.Add(_feedback.GetEntity(idTag));
            var quize = IocKernel.Get<IQuizze>().GetEntity(idQuizze);
            var ecpected = _feedback.SearchQuizzesByTeg(tags).Select(t =>t.NameQuiz).ToList();
            CollectionAssert.Contains(ecpected, quize.NameQuiz);

        }
        //
        // Создание(добавление) тега
        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        [TestCase("4")]
        [TestCase("5")]
        public void AddTegTest(string text)
        {
            _feedback.AddTeg(text);
            CollectionAssert.Contains(_feedback.GetListEntity().Select(t => t.Text).ToList(), text);
        }
        //
        // Удаление тега
        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        [TestCase("4")]
        [TestCase("5")]
        public void RemoveTegTest(string text)
        {
            _feedback.RemoveTeg(text);
            CollectionAssert.DoesNotContain(_feedback.GetListEntity().Select(t => t.Text).ToList(), text);
        }
    }
}