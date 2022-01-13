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
    public class FeedbackTests
    {
        private FeedbackRepo _feedback = new FeedbackRepo();
        //
        //  
        [Test]
        public void GetListEntityTest()
        {
            var expected = _feedback.GetListEntity().Select(t =>t.ID_Feedback);
            var actual = new ObservableCollection<Feedback>();
            //TODO добавить когда появится
            CollectionAssert.AreEqual(expected, actual.Select(t =>t.ID_Feedback));
        }
        //
        //
        [TestCase(1, 1, 1, "text")] //TODO исправить когда появятся попытки в бд
        public void GetEntityTest(long id_feedback, long id_quiz, long id_user, string text)
        {
            Feedback feedback = _feedback.GetEntity(id_feedback);
            Assert.Equals(feedback.ID_Quiz, id_quiz);
            Assert.Equals(feedback.ID_User, id_user);
            Assert.Equals(feedback.Text, text);

        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _feedback.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTestOne()
        {
            Feedback item = new Feedback();
            item.ID_User = 0;
            Assert.Throws<System.InvalidOperationException>(() => _feedback.Create(item));
        }
        [Test]
        public void CreateNegativeTestTwo()
        {
            Feedback item = new Feedback();
            item.ID_Quiz = 0;
            Assert.Throws<System.InvalidOperationException>(() => _feedback.Create(item));
        }
        [Test]
        public void CreateNegativeTestThree()
        {
            Feedback item = new Feedback();
            item.Text = "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890";
            Assert.Throws<System.InvalidOperationException>(() => _feedback.Create(item));
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _feedback.Delete(0));
        }
    }
}