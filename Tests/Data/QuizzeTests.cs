using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Data;
using Data.Repositories;
using Data.Maps;

using NUnit.Framework;
using Tests.Logic;

namespace Tests.Data
{
    [TestFixture]
    public class QuzzeTests
    {
        private QuizzeRepo _quizze = new QuizzeRepo();
        //
        //  
        [Test]
        public void GetListEntityTest()
        {
            var expected = _quizze.GetListEntity().Select(t =>t.ID_Quiz);
            var actual = new ObservableCollection<long>{2};
            CollectionAssert.AreEqual(expected, actual);
        }
        //
        //
        [TestCase(2, 6, 15, "Кто ты из Winx?")] //TODO исправить когда появятся попытки в бд
        public void GetEntityTest(long id_quizze, long id_user, int max_point, string name)
        {
            Quizze quiz = _quizze.GetEntity(id_quizze);
            Assert.Equals(quiz.ID_UserCreateons, id_user);
            Assert.Equals(quiz.MaxPoints, max_point);
            Assert.Equals(quiz.Name, name);

        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _quizze.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTestOne()
        {
            Quizze item = new Quizze();
            item.ID_UserCreateons = 0;
            Assert.Throws<System.InvalidOperationException>(() => _quizze.Create(item));
        }
        
        [Test]
        public void CreateNegativeTestTwo()
        {
            Quizze item = new Quizze();
            item.Name = "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890";
            Assert.Throws<System.InvalidOperationException>(() => _quizze.Create(item));
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _quizze.Delete(0));
        }
    }
}