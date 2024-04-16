using System;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private Axe axe;
        [SetUp]
        public void Setup()
        {
            dummy = new Dummy(10, 10);
            axe = new Axe(3, 6);
        }

        [Test]
        public void Dummy_LosesHealth_If_Attacked()
        {
            axe.Attack(dummy);
            Assert.AreEqual(dummy.Health.Equals(7),true);
        }
        [Test]
        public void Dead_Dummy_Throws_An_Exception_If_Attacked()
        {
            Dummy deadDummy = new Dummy(0, 0);
            Assert.Catch<InvalidOperationException>(() =>
            {
                axe.Attack(deadDummy);
            });
        }
        [Test]
        public void Dead_Dummy_Can_Give_XP()
        {
            Dummy deadDummy = new Dummy(0, 5);
            Assert.AreEqual(deadDummy.GiveExperience().Equals(5),true);
        }
        [Test]
        public void Alive_Dummy_Can_Give_XP()
        {
            Assert.Catch<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }

    }
}