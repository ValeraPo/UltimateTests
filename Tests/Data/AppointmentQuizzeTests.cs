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
    public class AppointmentQuizzeTests
    {
        private AppointmentQuizRepo _appointment = new AppointmentQuizRepo();
        //
        //  
       [Test]
        public void GetListEntityTest()
        {
            var expected = _appointment.GetListEntity().Select(t =>t.ID_Appointment);
            var actual = new ObservableCollection<AppointmentQuizze>();
            //TODO добавить когда появится
            CollectionAssert.AreEqual(expected, actual.Select(t =>t.ID_Appointment));
        }
        //
        //
        [TestCase(1, 1, 1)] //TODO исправить когда появятся назначения в бд
        public void GetEntityTest(long id_appoinment, long id_quiz, long id_user)
        {
            AppointmentQuizze appointmentQuizze = _appointment.GetEntity(id_appoinment);
            Assert.Equals(appointmentQuizze.ID_Quiz, id_quiz);
            Assert.Equals(appointmentQuizze.ID_User, id_user);

            
        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _appointment.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTestOne()
        {
            AppointmentQuizze item = new AppointmentQuizze();
            item.ID_User = 0;
            Assert.Throws<System.InvalidOperationException>(() => _appointment.Create(item));
        }
        [Test]
        public void CreateNegativeTestTwo()
        {
            AppointmentQuizze item = new AppointmentQuizze();
            item.ID_Quiz = 0;
            Assert.Throws<System.InvalidOperationException>(() => _appointment.Create(item));
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _appointment.Delete(0));
        }
    }
}