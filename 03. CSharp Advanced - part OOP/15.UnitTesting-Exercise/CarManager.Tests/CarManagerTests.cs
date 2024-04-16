using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Test_Car_Public_Constructor_Should_Working_Properly()
        {
            Car car = new Car("BMW", "E46", 10, 80);
            Assert.That(car, Is.Not.Null);
            Assert.AreEqual("BMW",car.Make);
            Assert.AreEqual("E46",car.Model);
            Assert.AreEqual(10, car.FuelConsumption);
            Assert.AreEqual(80, car.FuelCapacity);
        }
        [Test]
        public void Test_Car_Private_Constructor_Should_Set_Fuel_Amount_To_0()
        {
            Car car = new Car("BMW", "E46", 10, 80);
            int expectedAmount = 0;
            Assert.AreEqual(expectedAmount,car.FuelAmount);
        }

        [Test]
        [TestCase("BMW", "E46", 10, 80)]
        [TestCase("Audi","80", 8, 40)]
        public void Test_Car_GettersAnd_Setters_Should_Work_Properly(string make, string model,
            double fuelConsumption,double fuelCapacity )
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(make,car.Make);
            Assert.AreEqual(model,car.Model);
            Assert.AreEqual(fuelConsumption,car.FuelConsumption);
            Assert.AreEqual(fuelCapacity,car.FuelCapacity);
            Assert.AreEqual(0,car.FuelAmount);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Test_Car_Make_Should_Throw_Exception_When_Empty(string make)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                new Car(make, "2107", 9, 60));
            Assert.AreEqual($"Make cannot be null or empty!",exception.Message);
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Test_Car_Model_Should_Throw_Exception_When_Empty(string model)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                new Car("Lada", model, 9, 60));
            Assert.AreEqual($"Model cannot be null or empty!", exception.Message);
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-333)]
        public void Test_Car_FuelConsumption_Should_Throw_Exception_When_Empty(double fuelConsumption)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                new Car("Lada", "2107", fuelConsumption, 60));
            Assert.AreEqual($"Fuel consumption cannot be zero or negative!", exception.Message);
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-333)]
        public void Test_Car_FuelCapacity_Should_Throw_Exception_When_Empty(double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                new Car("Lada", "2107", 8, fuelCapacity));
            Assert.AreEqual($"Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void Test_Car_Refuel_Method_Should_Work_Correctly()
        {
            Car car = new Car("BMW", "E46", 10, 80);
            car.Refuel(40);
            int expectedFuel = 40;
            Assert.AreEqual(expectedFuel,car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-24)]
        public void Test_Car_Refuel_Method_Should_Throw_Exception_If_Fuel_Is_NegativeOrZero(double fuel)
        {
            Car car = new Car("BMW", "E46", 10, 80);
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                car.Refuel(fuel));
            Assert.AreEqual($"Fuel amount cannot be zero or negative!", exception.Message);
        }

        [Test]
        [TestCase(30)]
        [TestCase(80)]
        [TestCase(180)]
        public void Test_Car_Refuel_MethodTo_Put_More_Fuel_Than_FuelTank_Capacity(double fuel)
        {
            Car car = new Car("BMW", "E46", 10, 80);
            car.Refuel(60);
            car.Refuel(fuel);
            int expectedFuel = 80;
            Assert.AreEqual(80,car.FuelAmount);
        }

        [Test]
        public void Test_Car_Drive_Method_Should_Work_Correctly()
        {
            Car car = new Car("BMW", "E46", 10, 80);
            car.Refuel(80);
            car.Drive(20);
            int carIntialFuelAmount = 80;
            Assert.AreNotEqual(carIntialFuelAmount,car.FuelAmount);
        }
        [Test]
        [TestCase("BMW", "E46", 10, 80)]
        [TestCase("Mitsubishi", "Galant", 12, 40)]

        public void Test_Car_Drive_Method_Should_Work_Throw_Exception_When_Refuel_Is_NotEnough(
            string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make,model,fuelConsumption,fuelCapacity);
            car.Refuel(15);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                car.Drive(400));
            Assert.AreEqual($"You don't have enough fuel to drive!",exception.Message);
        }

    }
}