using System;
using System.Collections.ObjectModel;
using System.Linq;
using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;
using Logic.Processes;
using NUnit.Framework;

namespace Tests.Logic
{
    [TestFixture]
    public class GroupTests
    {
        private IGroup _group = IocKernel.Get<IGroup>();
        //
        // Добавление группы 
        public enum NewGroups
        {
            one,
            two,
            three,
            four,
            five
        }
        public static GroupDTO AddGroupMockOutputData(NewGroups user)
        {
            switch (user)
            {
                case NewGroups.one: 
                {
                    return new GroupDTO(14, "1");
                }
                case NewGroups.two: 
                {
                    return new GroupDTO(15, "2");
                }
                case NewGroups.three: 
                {
                    return new GroupDTO(16, "3");
                }
                case NewGroups.four: 
                {
                    return new GroupDTO(17, "4");
                }
                case NewGroups.five: 
                {
                    return new GroupDTO(18,  "5");
                }
                
                default: throw new ArgumentException();
            }
        }
        
        [TestCase(NewGroups.one,  "1")]
        [TestCase(NewGroups.two,  "2")]
        [TestCase(NewGroups.three, "3")]
        [TestCase(NewGroups.four,  "4")]
        [TestCase(NewGroups.five,  "5")]

        public void AddGroupTest(NewGroups group,  string name)
        {
            _group.AddGroup(name);
            var expected = AddGroupMockOutputData(group);
            var actual = _group.GetEntity(name);
            Assert.AreEqual(expected.NameOfGroup, actual.NameOfGroup);
        }

        [Test]
        public void AddNewUserNegativeTest()
        {
            Assert.Throws<ArgumentException>(() => _group.AddGroup("1"));
        }
        //
        //Добавить тег группе
        [TestCase("1")]
        [TestCase("2")]
        [TestCase( "3")]
        [TestCase( "4")]
        [TestCase( "5")]
        public void AddTagTest(string nameGroup)
        {
            // Создаем DTO классы группы и теги
            var setTag = IocKernel.Get<SetTag>();
            var group = _group.GetEntity(nameGroup);
            var tag = setTag.GetEntity(16);
            // Запускаем метод который проверяем
            _group.AddTag(group, tag);
            // Создаем коллекцию, которая содержит только что добавленный тег
            var tags = new ObservableCollection<SetTagDTO>();
            tags.Add(tag);
            // Вытаскиваем из БД групы по тегу          
            var expexted = setTag.SearchGroupByTeg(tags).Select(t =>t.NameOfGroup);

            
            CollectionAssert.Contains(expexted, group.NameOfGroup);
        }
        //
        // Удаление группы
        [TestCase(NewGroups.one)]
        [TestCase(NewGroups.two)]
        [TestCase(NewGroups.three)]
        [TestCase(NewGroups.four)]
        [TestCase(NewGroups.five)]
        public void RemoveGroupTest(NewGroups group)
        {
            var myGroup = AddGroupMockOutputData(group);
            _group.RemoveGroup(myGroup.NameOfGroup);

            CollectionAssert.DoesNotContain(_group.GetListEntity().Select(t => t.NameOfGroup).ToList(), myGroup.NameOfGroup);
        }
        
    }
}