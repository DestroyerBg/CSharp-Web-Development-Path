using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        [SetUp]
        public void Setup()
        {
            axe = new Axe(3, 3); 
            dummy = new Dummy(4, 4);
        }
        [Test]
        public void Axe_Looses_Durability_AfterEachAttack()
        {
            Axe axe = new Axe(3, 3);
            Dummy dummy = new Dummy(4, 4);
            axe.Attack(dummy);
            Assert.AreEqual(axe.DurabilityPoints.Equals(2), true);
        }
        [Test]
        public void TestToAttackDummyWithBrokenAxe()
        {
            Axe brokenAxe = new Axe(5,0);
            Assert.Catch<InvalidOperationException>(() =>
            {
                brokenAxe.Attack(dummy);
            });
        }
    }
}