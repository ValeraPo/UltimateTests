using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Data;
using Data.Interfaces;
using Data.Repositories;
using Data.Maps;
using Logic.Configuration;
using NUnit.Framework;
using Tests.Logic;

namespace Tests.Data
{
    [TestFixture]
    public class AttemptTests
    {
        private IRepository<Attempt> _attempt = IocKernel.Get<IRepository<Attempt>>();
        //
        //  
       [Test]
        public void GetListEntityTest()
        {
            var expected = _attempt.GetListEntity().Select(t =>t.ID_Try);
            var actual = new ObservableCollection<Attempt>();
            //TODO добавить когда появится
            CollectionAssert.AreEqual(expected, actual.Select(t =>t.ID_Try));
        }
        //
        //
        //[TestCase(1, 1, 1)] //TODO исправить когда появятся попытки в бд
        public void GetEntityTest(long id_attempt, long id_quiz, long id_user)
        {
            Attempt attempt = _attempt.GetEntity(id_attempt);
            Assert.AreEqual(attempt.ID_Quiz, id_quiz);
            Assert.AreEqual(attempt.ID_User, id_user);
        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => _attempt.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTestOne()
        {
            Attempt item = new Attempt();
            item.ID_User = 0;
            _attempt.Create(item);
            Assert.Throws<System.Data.Entity.Infrastructure.DbUpdateException>(() => _attempt.Save());
        }
        [Test]
        public void CreateNegativeTestTwo()
        {
            Attempt item = new Attempt();
            item.ID_Quiz = 0;
            _attempt.Create(item);
            Assert.Throws<System.Data.Entity.Infrastructure.DbUpdateException>(() => _attempt.Save());
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<NotImplementedException>(() => _attempt.Delete(0));
        }
    }
}