using System;
using System.Linq;
using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;
using Logic.Processes;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GroupTests
    {
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
                    return new GroupDTO(18,  "4");
                }
                
                default: throw new ArgumentException();
            }
        }
        [TestCase(NewGroups.one, 14, "1")]
        [TestCase(NewGroups.two, 15, "3")]
        [TestCase(NewGroups.three, 16, "3")]
        [TestCase(NewGroups.four, 17, "4")]
        [TestCase(NewGroups.five, 18, "5")]

        public void AddNewUserTest(NewGroups group, long id_group, string name)
        {
            //IocKernel.Initialize(new ProjectConfiguration());
            IocKernel.Get<IGroup>().AddGroup(name);
            var myGroup = AddGroupMockOutputData(group);
            Assert.AreEqual(myGroup, IocKernel.Get<IGroup>().GetEntity(id_group));
            IocKernel.Get<IGroup>().RemoveGroup(myGroup);
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
            //IocKernel.Initialize(new ProjectConfiguration());
            var myGroup = AddGroupMockOutputData(group);
            IocKernel.Get<IGroup>().RemoveGroup(myGroup);

            CollectionAssert.DoesNotContain(IocKernel.Get<IGroup>().GetListEntity().Select(t => t.NameOfGroup).ToList(), myGroup.NameOfGroup);
        }
    }
}