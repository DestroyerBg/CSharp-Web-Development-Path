using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Skeleton;

namespace SkeletonTests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void Test_Dead_Dummy_Can_Give_XP()
        {
            var dummyMock = new Mock<ITarget>();
            dummyMock.SetupGet(d=>d.Health).Returns(0);
            dummyMock.Setup(d=>d.GiveExperience()).Returns(25);
            ITarget dummy = dummyMock.Object;
            Assert.IsNotNull(dummy);
            Assert.AreEqual(25,dummy.GiveExperience());
        }
    }
}
