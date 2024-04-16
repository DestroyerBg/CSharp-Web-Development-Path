using System;
using System.Reflection;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Test_Warrior_Constructor_Working_Properly()
        {
            Warrior warrior = new Warrior("Pesho", 23, 100);
            Assert.IsNotNull(warrior);
        }

        [Test]
        public void Test_Warrior_Name_Setter_And_Getter_Working_Properly()
        {
            Warrior warrior = new Warrior("Pesho", 23, 100);
            Assert.AreEqual("Pesho",warrior.Name);
        }
        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("               ")]
        public void Test_Warrior_Name_Setter_Throwing_Exception_When_Name_Is_Null_Or_Empty(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                new Warrior(name, 65, 54));
            Assert.AreEqual($"Name should not be empty or whitespace!",exception.Message);
        }

        [Test]
        public void Test_Warrior_Damage_Setter_Working_Properly()
        {
            Warrior warrior = new Warrior("Pesho", 23, 100);
            int expectedDamage = 23;
            Assert.AreEqual(expectedDamage,warrior.Damage);
        }
        [Test]
        [TestCase (0)]
        [TestCase (-1)]
        [TestCase (-333)]
        [TestCase(null)]
        public void Test_Warrior_Damage_Setter_Throwing_Exception_When_Damage_Is_Zero_Or_Negative(int damage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                new Warrior("Pesho", damage, 54));
            Assert.AreEqual($"Damage value should be positive!", exception.Message);
        }
        [Test]
        public void Test_Warrior_HP_Setter_Working_Properly()
        {
            Warrior warrior = new Warrior("Pesho", 23, 100);
            int expectedHp = 100;
            Assert.AreEqual(expectedHp, warrior.HP);
        }
        [Test]
        public void Test_Warrior_HP_Setter_Working_With_Zero_Health()
        {
            Warrior warrior = new Warrior("Pesho", 23, 0);
            int expectedHp = 0;
            Assert.AreEqual(expectedHp, warrior.HP);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-333)]
        public void Test_Warrior_HP_Setter_Throwing_Exception_When_Damage_Is_Negative(int Hp)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                new Warrior("Pesho", 23, Hp));
            Assert.AreEqual($"HP should not be negative!", exception.Message);
        }

        [Test]
        [TestCase("Pesho", 75, 29)]
        [TestCase("Sasho", 75, 1)]
        [TestCase("Pesho", 75, 0)]
        [TestCase("Anton", 75, 30)]
        public void Warrior_Cannot_Attack_If_His_Hp_Is_Equal_Or_Below30(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Warrior warrior2 = new Warrior("Gosho", 30, 70);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                warrior.Attack(warrior2));
            Assert.AreEqual($"Your HP is too low in order to attack other warriors!", exception.Message);
        }
        [Test]
        [TestCase("Pesho", 75, 29)]
        [TestCase("Sasho", 75, 1)]
        [TestCase("Pesho", 75, 0)]
        [TestCase("Anton", 75, 30)]
        public void Warrior_Cannot_Attack_If_Enemy_Hp_Is_Below_Or_Equal_To_30(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior("Destroyer", 75, 45);
            Warrior warrior2 = new Warrior(name, damage, hp);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                warrior.Attack(warrior2));
            Assert.AreEqual($"Enemy HP must be greater than 30 in order to attack him!", exception.Message);
        }

        [Test]
        public void Warrior_Cannot_Attack_Stronger_Enemies()
        {
            Warrior destroyer = new Warrior("Destroyer", 75, 100);
            Warrior warrior2 = new Warrior("Pesho", 30, 60);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                warrior2.Attack(destroyer));
            Assert.AreEqual($"You are trying to attack too strong enemy",exception.Message);
        }

        [Test]
        public void Warrior_Attack_Works_Successfully_And_Reduces_Enemy_HP()
        {
            Warrior destroyer = new Warrior("Destroyer", 50, 100);
            Warrior warrior2 = new Warrior("Pesho", 30, 70);
            destroyer.Attack(warrior2);
            int expectedHealth = 20;
            Assert.AreEqual(expectedHealth,warrior2.HP);
        }
        [Test]
        public void Warrior_Attack_Works_Successfully_And_Reduces_Attacking_Warrior_HP()
        {
            Warrior destroyer = new Warrior("Destroyer", 50, 100);
            Warrior warrior2 = new Warrior("Pesho", 30, 70);
            destroyer.Attack(warrior2);
            int expectedHealth = 70;
            Assert.AreEqual(expectedHealth, destroyer.HP);
        }
        
        [Test]
        public void Warrior_Kills_Attacked_Warrior()
        {
            Warrior destroyer = new Warrior("Destroyer", 80, 100);
            Warrior warrior2 = new Warrior("Pesho", 30, 70);
            int expectedHealth = 0;
            destroyer.Attack(warrior2);
            Assert.AreEqual(expectedHealth, warrior2.HP);
        }



    }
    
}