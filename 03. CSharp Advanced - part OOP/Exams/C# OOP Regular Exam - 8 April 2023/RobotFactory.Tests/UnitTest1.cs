using NUnit.Framework;
using System.Diagnostics;
using System.Reflection;

namespace RobotFactory.Tests
{
    public class Tests
    {

        [Test]
        public void Test_Factory_Constructor_Works_Correctly()
        {
            Factory factory = new Factory("Bai biser", 5);
            Assert.IsNotNull(factory);
            Assert.AreEqual("Bai biser",factory.Name);
            Assert.AreEqual(5,factory.Capacity);
            Assert.IsNotNull(factory.Robots);
            Assert.IsNotNull(factory.Supplements);
            Assert.AreEqual(0,factory.Robots.Count);
            Assert.AreEqual(0, factory.Supplements.Count);
        }

        [Test]
        public void Test_Robot_Constructor_Works_Correctly()
        {
            Robot robot = new Robot("Chichko", 3.50, 1600);
            Assert.IsNotNull(robot);
            Assert.AreEqual("Chichko",robot.Model);
            Assert.AreEqual(3.50, robot.Price);
            Assert.AreEqual(1600, robot.InterfaceStandard);
            Assert.IsNotNull(robot.Supplements);
            Assert.AreEqual(0, robot.Supplements.Count);
        }

        [Test]
        public void Test_Supplement_Constructor_Works_Correctly()
        {
            Supplement supplement = new Supplement("Chast", 1200);
            Assert.IsNotNull(supplement);
            Assert.AreEqual("Chast",supplement.Name);
            Assert.AreEqual(1200,supplement.InterfaceStandard);
        }

        [Test]
        public void Test_RobotToString_Works_Correctly()
        {
            Robot robot = new Robot("Chichko", 895.93, 850);
            Robot robot1 = new Robot("Parichko", 1015, 123);
            Robot robot2 = new Robot("Nokia", 100.00, 3310);
            Assert.AreEqual($"Robot model: Chichko IS: 850, Price: 895.93",robot.ToString());
            Assert.AreEqual($"Robot model: Parichko IS: 123, Price: 1015.00", robot1.ToString());
            Assert.AreEqual($"Robot model: Nokia IS: 3310, Price: 100.00", robot2.ToString());
        }

        [Test]
        public void Test_Supplement_ToString_Works_Correctly()
        {
            Supplement supplement = new Supplement("Chast", 3105);
            Assert.AreEqual($"Supplement: Chast IS: 3105",supplement.ToString());
        }
        [Test]
        public void Test_ProduceRobot_Method_Works_Correctly()
        {
            Robot robot = new Robot("Chichko", 895.93, 850);
            Factory factory = new Factory("Samsung", 3);
            Assert.AreEqual(0,factory.Robots.Count);
            Assert.AreEqual($"Produced --> Robot model: Chichko IS: 850, Price: 895.93",factory.ProduceRobot("Chichko",895.93,850));
            Assert.AreEqual($"Produced --> Robot model: Parichko IS: 123, Price: 1015.00", factory.ProduceRobot("Parichko", 1015, 123));
            Assert.AreEqual($"Produced --> Robot model: Nokia IS: 3310, Price: 100.00", factory.ProduceRobot("Nokia", 100.00, 3310));
            Assert.AreEqual($"The factory is unable to produce more robots for this production day!", factory.ProduceRobot("Nokia", 100.00, 3310));
            Assert.AreEqual(3,factory.Robots.Count);
        }

        [Test]
        public void Test_ProduceSupplement_Method_Works_Correctly()
        {
            Factory factory = new Factory("Samsung", 3);
            Assert.AreEqual(0,factory.Supplements.Count);
            Assert.AreEqual($"Supplement: Chast IS: 3105", factory.ProduceSupplement("Chast", 3105));
            Assert.AreEqual(1,factory.Supplements.Count);
        }

        [Test]
        public void Test_UpgradeRobot_Method_Works_Correctly()
        {
            Factory factory = new Factory("Samsung", 3);
            Robot robot = new Robot("Chichko", 895.93, 850);
            Robot robot1 = new Robot("Parichko", 1015, 123);
            Robot robot2 = new Robot("Nokia", 100.00, 3310);
            Supplement supplement = new Supplement("Chast", 850);
            Supplement supplement1 = new Supplement("Chast", 123);
            Supplement supplement2 = new Supplement("Chast", 3310);
            Supplement supplement3 = new Supplement("Chast", 4141);
            factory.ProduceRobot("Chichko", 895.93, 850);
            factory.ProduceRobot("Parichko", 1015, 123);
            factory.ProduceRobot("Nokia", 100.00, 3310);
            Assert.IsTrue(factory.UpgradeRobot(robot,supplement));
            Assert.IsTrue(factory.UpgradeRobot(robot1, supplement1));
            Assert.IsTrue(factory.UpgradeRobot(robot2, supplement2));
            Assert.IsFalse(factory.UpgradeRobot(robot, supplement3));
            Assert.AreEqual(1,robot.Supplements.Count);
            Assert.AreEqual(1, robot1.Supplements.Count);
            Assert.AreEqual(1, robot2.Supplements.Count);

        }

        [Test]
        public void Test_SellRobot_Works_Correctly()
        {
            Factory factory = new Factory("Samsung", 3);
            factory.ProduceRobot("Chichko", 895.93, 850);
            factory.ProduceRobot("Parichko", 1015, 123);
            factory.ProduceRobot("Nokia", 100.00, 3310);
            Robot robot = new Robot("Chichko", 895.93, 850);
            Robot robot1 = new Robot("Parichko", 1015, 123);
            Robot robot2 = new Robot("Nokia", 100.00, 3310);
            Assert.AreEqual(3,factory.Robots.Count);
            Robot robotSell = factory.SellRobot(1000); 
            Assert.IsNotNull(robotSell);
            Assert.AreEqual(robotSell.ToString(),robot.ToString());
        }
    }
}