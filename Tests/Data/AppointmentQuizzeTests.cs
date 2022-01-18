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
    public class AppointmentQuizzeTests
    {
        private IRepository<AppointmentQuizze> _appointment = IocKernel.Get<IRepository<AppointmentQuizze>>();
        //
        //  
        [Test]
        public void GetListEntityTest()
        {
            var expected = _appointment.GetListEntity().Select(t => t.ID_Appointment);
            var actual   = new ObservableCollection<long> { 9, 10, 11, 12, 13 };
            CollectionAssert.AreEqual(expected, actual);
        }
        //
        //
        [TestCase(9, 24, 13)]
        [TestCase(10, 25, 3)]
        [TestCase(11, 26, 4)]
        [TestCase(12, 27, 5)]
        [TestCase(13, 28, 19)]
        public void GetEntityTest(long id_appoinment, long id_quiz, long id_user)
        {
            AppointmentQuizze appointmentQuizze = _appointment.GetEntity(id_appoinment);
            Assert.AreEqual(appointmentQuizze.ID_Quiz, id_quiz);
            Assert.AreEqual(appointmentQuizze.ID_User, id_user);
        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => _appointment.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTestOne()
        {
            AppointmentQuizze item = new AppointmentQuizze();
            item.ID_User = 0;
            _appointment.Create(item);
            Assert.Throws<System.Data.Entity.Infrastructure.DbUpdateException>(() => _appointment.Save());
        }
        [Test]
        public void CreateNegativeTestTwo()
        {
            AppointmentQuizze item = new AppointmentQuizze();
            item.ID_Quiz = 0;
            _appointment.Create(item);
            Assert.Throws<System.Data.Entity.Infrastructure.DbUpdateException>(() => _appointment.Save());
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => _appointment.Delete(0));
        }
    }
}