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
    public class FeedbackTests
    {
        private readonly IRepository<Feedback> _feedback = IocKernel.Get<IRepository<Feedback>>();
        //
        //  
        [Test]
        public void GetListEntityTest()
        {
            var expected = _feedback.GetListEntity().Select(t => t.ID_Feedback);
            var actual   = new ObservableCollection<long> { 19, 20, 21, 22, 23 };
            CollectionAssert.AreEqual(expected, actual);
        }
        //
        //
        [TestCase(19, 2, 13, "один")]
        [TestCase(20, 2, 3, "два")]
        [TestCase(21, 2, 4, "три")]
        [TestCase(22, 2, 5, "4tblre")]
        [TestCase(23, 2, 19, "pyat'")]
        public void GetEntityTest(long id_feedback, long id_quiz, long id_user, string text)
        {
            Feedback feedback = _feedback.GetEntity(id_feedback);
            Assert.AreEqual(feedback.ID_Quiz, id_quiz);
            Assert.AreEqual(feedback.ID_User, id_user);
            Assert.AreEqual(feedback.Text, text);
        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => _feedback.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTestOne()
        {
            Feedback item = new Feedback();
            item.ID_User = 0;
            _feedback.Create(item);
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _feedback.Save());
        }
        [Test]
        public void CreateNegativeTestTwo()
        {
            Feedback item = new Feedback();
            item.ID_Quiz = 0;
            _feedback.Create(item);
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _feedback.Save());
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
            _feedback.Create(item);
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _feedback.Save());
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => _feedback.Delete(0));
        }
    }
}