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
        private ISetTag _tags = IocKernel.Get<ISetTag>();
        //
        // Возврат групп по тегу
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(1, 4)]
        public void SearchGroupByTegTest(long idGroup, long idTag)
        {
            var tags = new ObservableCollection<SetTagDTO>();
            tags.Add(_tags.GetEntity(idTag));
            var group = IocKernel.Get<IGroup>().GetEntity(idGroup);
            var ecpected = _tags.SearchGroupByTeg(tags).Select(t=>t.NameOfGroup);
            CollectionAssert.Contains(ecpected, group.NameOfGroup);

        }
        //
        // Возврат тестов по тегу
        [TestCase(2, 17)]
        public void SearchQuizzeTegTest(long idQuizze, long idTag)
        {
            var tags = new ObservableCollection<SetTagDTO>();
            tags.Add(_tags.GetEntity(idTag));
            var quize = IocKernel.Get<IQuizze>().GetEntity(idQuizze);
            var ecpected = _tags.SearchQuizzesByTeg(tags).Select(t =>t.NameQuiz).ToList();
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
            _tags.AddTeg(text);
            CollectionAssert.Contains(_tags.GetListEntity().Select(t => t.Text).ToList(), text);
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
            _tags.RemoveTeg(text);
            CollectionAssert.DoesNotContain(_tags.GetListEntity().Select(t => t.Text).ToList(), text);
        }
    }
}