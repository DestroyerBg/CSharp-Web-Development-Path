using System.Linq;

namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            arena.Enroll(new Warrior("Destroyer", 70, 100));
            arena.Enroll(new Warrior("TheNitro", 50, 50));
            arena.Enroll(new Warrior("Pesho", 40, 80));
            arena.Enroll(new Warrior("Gosho", 55, 55));
        }

        [Test]
        public void Test_Arena_Constructor_Works_Correctly()
        {
            Arena arena2 = new Arena();
            Assert.IsNotNull(arena);
        }

        [Test]
        public void Test_Arena_Count_Works_Properly()
        {
            Assert.IsNotNull(arena.Count);
            Assert.AreEqual(4, arena.Count);
        }

        [Test]
        public void Test_Arena_Warriors_Collection_Works_Correctly()
        {
            var warriors = arena.Warriors;
            Assert.IsNotNull(warriors);
            Assert.AreEqual(warriors,arena.Warriors);
        }
        [Test]
        public void Test_Enroll_Method_Works_Properly()
        {
            Arena arena2 = new Arena();
            arena2.Enroll(new Warrior("TheNitro", 50, 50));
            Assert.IsNotEmpty(arena2.Warriors);
        }

        [Test]
        public void Test_Enrolling_Already_Enrolled_Warrior()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                arena.Enroll(new Warrior("Destroyer", 70, 100)));
            Assert.AreEqual($"Warrior is already enrolled for the fights!", exception.Message);
        }
        [Test]
        public void Test_Fight_Method_Works_Properly()
        {
            arena.Fight("Destroyer", "TheNitro");
            int attackerHp = 50;
            int defenderHp = 0;
            Assert.AreEqual(attackerHp,arena.Warriors.First(n=>n.Name == "Destroyer").HP);
            Assert.AreEqual(defenderHp, arena.Warriors.First(n => n.Name == "TheNitro").HP);
        }
        [TestCase ("BMW")]
        [TestCase("Zafira")]
        [TestCase("Test")]
        [Test]
        public void Test_Attacking_Missing_Fighters_Throws_Exception(string name)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                arena.Fight("Destroyer", name));
            Assert.AreEqual($"There is no fighter with name {name} enrolled for the fights!",exception.Message);
            InvalidOperationException exception2 = Assert.Throws<InvalidOperationException>(() =>
                arena.Fight(name, "Destroyer"));
            Assert.AreEqual($"There is no fighter with name {name} enrolled for the fights!", exception2.Message);
        }
    }
}
