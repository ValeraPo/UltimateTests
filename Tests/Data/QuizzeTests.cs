using System;
using System.Collections.ObjectModel;
using System.Linq;
using Data.Interfaces;
using Data.Maps;
using Logic.Configuration;
using NUnit.Framework;

namespace Tests.Data
{
    [TestFixture]
    public class QuzzeTests
    {
        private readonly IRepository<Quizze> _quizze = IocKernel.Get<IRepository<Quizze>>();
        //
        //  
        [Test]
        public void GetListEntityTest()
        {
            var expected = _quizze.GetListEntity().Select(t => t.ID_Quiz);
            var actual   = new ObservableCollection<long> { 2, 24, 25, 26, 27, 28 };
            CollectionAssert.AreEqual(expected, actual);
        }
        //
        //
        [TestCase(2, 6, 15, "Кто ты из Winx?")]
        [TestCase(24, 6, 10, "один")]
        [TestCase(25, 7, 11, "два")]
        [TestCase(26, 7, 14, "три")]
        [TestCase(27, 6, 156, "4tblre")]
        [TestCase(28, 7, 16, "pyat'")]
        public void GetEntityTest(long id_quizze, long id_user, int max_point, string name)
        {
            Quizze quiz = _quizze.GetEntity(id_quizze);
            Assert.AreEqual(quiz.ID_UserCreateons, id_user);
            Assert.AreEqual(quiz.MaxPoints, max_point);
            Assert.AreEqual(quiz.Name, name);
        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => _quizze.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTestOne()
        {
            Quizze item = new Quizze();
            item.ID_UserCreateons = 0;
            _quizze.Create(item);
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _quizze.Save());
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
            _quizze.Create(item);
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _quizze.Save());
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => _quizze.Delete(0));
        }
    }
}