using System.Linq;
using Logic.Configuration;
using Logic.Interfaces;
using NUnit.Framework;

namespace Tests.Logic
{
    [TestFixture]
    public class ZFeedbackTests
    {
        private IFeedback _feedback = IocKernel.Get<IFeedback>();
        //
        // Удаление фидбэка
        [TestCase("test1")]
        [TestCase("test2")]
        [TestCase("test3")]
        [TestCase("test4")]
        [TestCase("test5")]
        public void RemoveFeedbackTest(string text)
        {
            _feedback.RemoveFeedback(text);
            CollectionAssert.DoesNotContain(_feedback.GetListEntity().Select(t => t.Text).ToList(), text);
        }
        
        
    }
}