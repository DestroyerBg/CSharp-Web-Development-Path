using NUnit.Framework;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private CoffeeMat coffeeMat;

        [SetUp]
        public void SetUp()
        {
            coffeeMat = new CoffeeMat(1000, 10);
        }

        [Test]
        public void Test_Constructor_Works_Correctly()
        {
            Assert.IsNotNull(coffeeMat);
            Assert.AreEqual(1000, coffeeMat.WaterCapacity);
            Assert.AreEqual(10, coffeeMat.ButtonsCount);
            Assert.AreEqual(0, coffeeMat.Income);
        }

        [Test]
        public void Test_FillWaterTank_Works_Correctly()
        {
            coffeeMat.AddDrink("Kafe1", 0.50);
            coffeeMat.AddDrink("Kafe2", 0.70);
            coffeeMat.AddDrink("Kafe3", 0.80);
            coffeeMat.AddDrink("Kafe4", 0.90);
            coffeeMat.AddDrink("Kafe5", 1.00);
            Assert.AreEqual($"Water tank is filled with 1000ml", coffeeMat.FillWaterTank());
            coffeeMat.BuyDrink("Kafe1");
            coffeeMat.BuyDrink("Kafe2");
            coffeeMat.BuyDrink("Kafe3");
            Assert.AreEqual($"Water tank is filled with 240ml", coffeeMat.FillWaterTank());
            Assert.AreEqual($"Water tank is already full!", coffeeMat.FillWaterTank());

        }

        [Test]
        public void Test_AddDrink_Method_Works_Correctly()
        {
            Assert.IsTrue(coffeeMat.AddDrink("Kafe1", 0.50));
            Assert.IsTrue(coffeeMat.AddDrink("Kafe2", 0.50));
            Assert.IsTrue(coffeeMat.AddDrink("Kafe3", 0.50));
            Assert.IsTrue(coffeeMat.AddDrink("Kafe4", 0.50));
            Assert.IsTrue(coffeeMat.AddDrink("Kafe5", 0.50));
            Assert.IsTrue(coffeeMat.AddDrink("Kafe6", 0.50));
            Assert.IsTrue(coffeeMat.AddDrink("Kafe7", 0.50));
            Assert.IsTrue(coffeeMat.AddDrink("Kafe8", 0.50));
            Assert.IsTrue(coffeeMat.AddDrink("Kafe9", 0.50));
            Assert.IsFalse(coffeeMat.AddDrink("Kafe9", 0.50));
            CoffeeMat coffeeWithZeroButtons = new CoffeeMat(1000, 1);
            coffeeWithZeroButtons.AddDrink("Kafe1", 0.50);
            Assert.IsFalse(coffeeWithZeroButtons.AddDrink("Kafe9", 0.50));
            Assert.IsFalse(coffeeWithZeroButtons.AddDrink("Kafe10", 0.50));

        }

        [Test]
        public void Test_BuyDrink_Method_Works_Correctly()
        {
            coffeeMat.AddDrink("Kafe1", 0.30);
            coffeeMat.AddDrink("Kafe2", 0.50);
            coffeeMat.AddDrink("Kafe3", 0.80);
            coffeeMat.AddDrink("Kafe4", 0.50);
            coffeeMat.AddDrink("Kafe5", 1.20);
            coffeeMat.AddDrink("Kafe6", 0.50);
            coffeeMat.AddDrink("Kafe7", 1.00);
            coffeeMat.AddDrink("Kafe8", 0.50);
            coffeeMat.AddDrink("Kafe9", 1.50);
            coffeeMat.AddDrink("Kafe10", 1.40);
            coffeeMat.FillWaterTank();
            Assert.AreEqual($"Your bill is 0.50$", coffeeMat.BuyDrink("Kafe8"));
            CoffeeMat empty = new CoffeeMat(100, 5);
            empty.AddDrink("Kafe1", 0.30);
            empty.AddDrink("Kafe2", 0.50);
            Assert.AreEqual($"CoffeeMat is out of water!", empty.BuyDrink("Kafe1"));
            empty.FillWaterTank();
            empty.BuyDrink("Kafe1");
            Assert.AreEqual($"CoffeeMat is out of water!", empty.BuyDrink("Kafe2"));
            Assert.AreEqual($"Capuchino is not available!", coffeeMat.BuyDrink("Capuchino"));

        }
        [Test]
        public void Test_CollectIncome_Method_Works_Correctly()
        {
            Assert.AreEqual(0,coffeeMat.CollectIncome());
            coffeeMat.AddDrink("Kafe1", 0.30);
            coffeeMat.AddDrink("Kafe2", 0.50);
            coffeeMat.AddDrink("Kafe3", 0.80);
            coffeeMat.AddDrink("Kafe4", 0.50);
            coffeeMat.AddDrink("Kafe5", 1.20);
            coffeeMat.AddDrink("Kafe6", 0.50);
            coffeeMat.AddDrink("Kafe7", 1.00);
            coffeeMat.AddDrink("Kafe8", 0.50);
            coffeeMat.AddDrink("Kafe9", 1.50);
            coffeeMat.AddDrink("Kafe10", 1.40);
            coffeeMat.FillWaterTank();
            coffeeMat.BuyDrink("Kafe1");
            coffeeMat.BuyDrink("Kafe2");
            coffeeMat.BuyDrink("Kafe3");
            coffeeMat.BuyDrink("Kafe4");
            coffeeMat.BuyDrink("Kafe5");
            Assert.AreEqual(3.30,coffeeMat.Income);
            double income = coffeeMat.CollectIncome();
            Assert.AreEqual(3.30,income);
            Assert.AreEqual(0,coffeeMat.Income);
        }
    }
}