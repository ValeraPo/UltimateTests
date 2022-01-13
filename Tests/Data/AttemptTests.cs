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
    public class AttemptTests
    {
        private AttemptRepo _attempt = new AttemptRepo();
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
        [TestCase(1, 1, 1)] //TODO исправить когда появятся попытки в бд
        public void GetEntityTest(long id_attempt, long id_quiz, long id_user)
        {
            Attempt attempt = _attempt.GetEntity(id_attempt);
            Assert.Equals(attempt.ID_Quiz, id_quiz);
            Assert.Equals(attempt.ID_User, id_user);
        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _attempt.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTestOne()
        {
            Attempt item = new Attempt();
            item.ID_User = 0;
            Assert.Throws<System.InvalidOperationException>(() => _attempt.Create(item));
        }
        [Test]
        public void CreateNegativeTestTwo()
        {
            Attempt item = new Attempt();
            item.ID_Quiz = 0;
            Assert.Throws<System.InvalidOperationException>(() => _attempt.Create(item));
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _attempt.Delete(0));
        }
    }
}