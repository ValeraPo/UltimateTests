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
    public class SetTagTests
    {
        private SetTagRepo _tag = new SetTagRepo();
        //
        //  
        [Test]
        public void GetListEntityTest()
        {
            var expected = _tag.GetListEntity().Select(t =>t.ID_TagSet);
            var actual = new ObservableCollection<long>{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};
            CollectionAssert.AreEqual(expected, actual);
        }
        //
        //
        [TestCase(1, "4 курс")]
        [TestCase(2, "3 курс")]
        [TestCase(3, "2 курс")]
        [TestCase(4, "1 курс")]
        [TestCase(5, "Отделение ОМиВТ")]

        public void GetEntityTest(long id_tag, string name)
        {
            SetTag setTag = _tag.GetEntity(id_tag);
            Assert.Equals(setTag.Text, name);

        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _tag.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTest()
        {
            SetTag item = new SetTag();
            item.Text = "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890";
            Assert.Throws<System.InvalidOperationException>(() => _tag.Create(item));
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _tag.Delete(0));
        }
    }
}