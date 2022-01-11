using System;
using Logic.Configuration;
using Logic.Interfaces;
using NUnit.Framework;
namespace NUnit.Tests
{

    [SetUpFixture]
    public class Settings
    {
        [SetUp]
        public void Init()
        {
            IocKernel.Initialize(new ProjectConfiguration());
        }
    }
}