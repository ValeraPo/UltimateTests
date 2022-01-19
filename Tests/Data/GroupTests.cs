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
    public class GroupTests
    {
        private readonly IRepository<Group> _group = IocKernel.Get<IRepository<Group>>();
        //
        //  
        [Test]
        public void GetListEntityTest()
        {
            var expected = _group.GetListEntity().Select(t => t.ID_Group);
            var actual   = new ObservableCollection<long> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            CollectionAssert.AreEqual(expected, actual);
        }
        //
        //
        [TestCase(1, "12929/1   ")]
        [TestCase(2, "42941/1   ")]
        [TestCase(3, "32934/4   ")]
        [TestCase(4, "14875/3   ")]
        [TestCase(5, "32934/3   ")]
        public void GetEntityTest(long id_group, string nameOfGroup)
        {
            Group group = _group.GetEntity(id_group);
            Assert.AreEqual(group.NameOfGroup, nameOfGroup);
        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => _group.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTest()
        {
            Group item = new Group();
            item.NameOfGroup = "123456789012345";
            _group.Create(item);
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _group.Save());
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _group.Delete(0));
        }
    }
}