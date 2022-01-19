using System;
using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Data.Maps;
using Logic.Configuration;
using NUnit.Framework;

namespace Tests.Data
{
    [TestFixture]
    public class SetTagTests
    {
        private readonly IRepository<SetTag> _tag = IocKernel.Get<IRepository<SetTag>>();
        //
        //  
        [Test]
        public void GetListEntityTest()
        {
            var expected = _tag.GetListEntity().Select(t => t.ID_TagSet).ToList();
            var actual   = new List<long> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
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
            Assert.AreEqual(setTag.Text, name);
        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => _tag.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTest()
        {
            SetTag item = new SetTag();
            item.Text = "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890" +
                        "12345678901234567890123456789012345678901234567890";
            _tag.Create(item);
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _tag.Save());
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _tag.Delete(0));
        }
    }
}