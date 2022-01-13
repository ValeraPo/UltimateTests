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
    public class GroupTests
    {
        private GroupRepo _group = new GroupRepo();
        //
        //  
        [Test]
        public void GetListEntityTest()
        {
            var expected = _group.GetListEntity().Select(t =>t.ID_Group);
            var actual = new ObservableCollection<long> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            CollectionAssert.AreEqual(expected, actual);
        }
        //
        //
        [TestCase(1, "12929/1   ")]
        [TestCase(2, "42941/1   ")]
        [TestCase(3, "32934/1   ")]
        [TestCase(4, "14875/1   ")]
        [TestCase(5, "32934/1   ")]
        public void GetEntityTest(long id_group, string nameOfGroup)
        {
            Group group = _group.GetEntity(id_group);
            Assert.Equals(group.NameOfGroup, nameOfGroup);
        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _group.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTest()
        {
            Group item = new Group();
            item.NameOfGroup = "123456789012345";
            Assert.Throws<System.InvalidOperationException>(() => _group.Create(item));
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _group.Delete(0));
        }
    }
}