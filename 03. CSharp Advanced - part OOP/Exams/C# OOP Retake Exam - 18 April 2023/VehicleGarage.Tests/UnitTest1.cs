using System.Linq;
using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        private Garage garage;

        [SetUp]
        public void Setup()
        {
            garage = new Garage(10);
        }

        [Test]
        public void Test_Garage_Constructor_Works_Correctly()
        {
            Assert.IsNotNull(garage.Vehicles);
            Assert.IsNotNull(garage);
            Assert.AreEqual(10, garage.Capacity);
            Assert.AreEqual(0, garage.Vehicles.Count);
        }

        [Test]
        public void Test_Add_Vehicle_Method_Works_Correctly()
        {
            Assert.AreEqual(0, garage.Vehicles.Count);
            Assert.IsTrue(garage.AddVehicle(new Vehicle("BMW", "E46", "B6996TX")));
            Assert.AreEqual(1, garage.Vehicles.Count);
            Assert.IsFalse(garage.AddVehicle(new Vehicle("Mercedes", "C220", "B6996TX")));
            garage.AddVehicle(new Vehicle("Mercedes", "S65", "B6969TX"));
            garage.AddVehicle(new Vehicle("BMW", "E38", "B7038TX"));
            garage.AddVehicle(new Vehicle("BMW", "E39", "B3298TX"));
            Assert.IsTrue(garage.AddVehicle(new Vehicle("Mitsubishi", "Galant", "B2018TX")));
            garage.AddVehicle(new Vehicle("Audi", "80", "B1232TX"));
            garage.AddVehicle(new Vehicle("Seat", "Ibiza", "B7068TX"));
            garage.AddVehicle(new Vehicle("Audi", "A3", "B3456TX"));
            garage.AddVehicle(new Vehicle("Golf", "4", "B1234TX"));
            garage.AddVehicle(new Vehicle("Honda", "Civic", "B0889TX"));
            Assert.IsFalse(garage.AddVehicle(new Vehicle("Honda", "Civic", "B7889TX")));
        }

        [Test]
        public void Test_Vehicle_Constructor_Works_Correctly()
        {
            Vehicle vehicle = new Vehicle("BMW", "E46", "B6996TX");
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.IsFalse(vehicle.IsDamaged);
            Assert.AreEqual("BMW", vehicle.Brand);
            Assert.AreEqual("E46", vehicle.Model);
            Assert.AreEqual("B6996TX", vehicle.LicensePlateNumber);
        }

        [Test]
        public void Test_Charge_Vehicles_Works_Correctly()
        {
            garage.AddVehicle(new Vehicle("BMW", "E46", "B6996TX"));
            garage.AddVehicle(new Vehicle("Mercedes", "S65", "B6969TX"));
            garage.AddVehicle(new Vehicle("BMW", "E38", "B7038TX"));
            garage.AddVehicle(new Vehicle("BMW", "E39", "B3298TX"));
            garage.AddVehicle(new Vehicle("Mitsubishi", "Galant", "B2018TX"));
            garage.AddVehicle(new Vehicle("Audi", "80", "B1232TX"));
            garage.AddVehicle(new Vehicle("Seat", "Ibiza", "B7068TX"));
            garage.AddVehicle(new Vehicle("Audi", "A3", "B3456TX"));
            garage.AddVehicle(new Vehicle("Golf", "4", "B1234TX"));
            garage.AddVehicle(new Vehicle("Honda", "Civic", "B0889TX"));
            garage.DriveVehicle("B6996TX", 46, false);
            garage.DriveVehicle("B6969TX", 40, false);
            garage.DriveVehicle("B2018TX", 60, false);
            garage.DriveVehicle("B7068TX", 80, false);
            garage.DriveVehicle("B1234TX", 12, false);
            garage.DriveVehicle("B1232TX", 70, true);
            garage.DriveVehicle("B7038TX", 20, false);
            garage.DriveVehicle("B3298TX", 19, false);

            garage.ChargeVehicles(80);
            Assert.AreEqual(100, garage.Vehicles.Find(v => v.LicensePlateNumber == "B6996TX").BatteryLevel);
            Assert.AreEqual(100, garage.Vehicles.Find(v => v.LicensePlateNumber == "B6969TX").BatteryLevel);
            Assert.AreEqual(100, garage.Vehicles.Find(v => v.LicensePlateNumber == "B2018TX").BatteryLevel);
            Assert.AreEqual(100, garage.Vehicles.Find(v => v.LicensePlateNumber == "B7068TX").BatteryLevel);
            Assert.AreEqual(88, garage.Vehicles.Find(v => v.LicensePlateNumber == "B1234TX").BatteryLevel);
            Assert.AreEqual(100, garage.Vehicles.Find(v => v.LicensePlateNumber == "B1232TX").BatteryLevel);
            Assert.AreEqual(100, garage.Vehicles.Find(v => v.LicensePlateNumber == "B7038TX").BatteryLevel);
            Assert.AreEqual(81, garage.Vehicles.Find(v => v.LicensePlateNumber == "B3298TX").BatteryLevel);

        }

        [Test]
        public void Testing_DriveVehicle_Method_Works_Correctly()
        {
            int batteryDrain = 80;
            garage.AddVehicle(new Vehicle("BMW", "E46", "B6996TX"));
            garage.AddVehicle(new Vehicle("Mercedes", "S65", "B6969TX"));
            garage.AddVehicle(new Vehicle("BMW", "E38", "B7038TX"));
            garage.AddVehicle(new Vehicle("BMW", "E39", "B3298TX"));
            garage.AddVehicle(new Vehicle("Mitsubishi", "Galant", "B2018TX"));
            garage.AddVehicle(new Vehicle("Audi", "80", "B1232TX"));
            garage.AddVehicle(new Vehicle("Seat", "Ibiza", "B7068TX"));
            garage.AddVehicle(new Vehicle("Audi", "A3", "B3456TX"));
            garage.AddVehicle(new Vehicle("Golf", "4", "B1234TX"));
            garage.AddVehicle(new Vehicle("Honda", "Civic", "B0889TX"));
            garage.DriveVehicle("B6996TX", batteryDrain, false);
            garage.DriveVehicle("B1232TX", batteryDrain, false);
            garage.DriveVehicle("B1234TX", batteryDrain, true);
            Assert.AreEqual(100 - batteryDrain,
                garage.Vehicles.Find(v => v.LicensePlateNumber == "B6996TX").BatteryLevel);
            Assert.AreEqual(100 - batteryDrain,
                garage.Vehicles.Find(v => v.LicensePlateNumber == "B1232TX").BatteryLevel);
            Assert.AreEqual(100 - batteryDrain,
                garage.Vehicles.Find(v => v.LicensePlateNumber == "B1234TX").BatteryLevel);
            Assert.IsFalse(garage.Vehicles.Find(v => v.LicensePlateNumber == "B6996TX").IsDamaged);
            Assert.IsFalse(garage.Vehicles.Find(v => v.LicensePlateNumber == "B1232TX").IsDamaged);
            Assert.IsTrue(garage.Vehicles.Find(v => v.LicensePlateNumber == "B1234TX").IsDamaged);
            int expectedResult = garage.Vehicles.Find(v => v.LicensePlateNumber == "B1232TX").BatteryLevel;
            garage.DriveVehicle("B1232TX", batteryDrain, false);
            Assert.AreEqual(expectedResult, garage.Vehicles.Find(v => v.LicensePlateNumber == "B1232TX").BatteryLevel);

        }

        [Test]
        public void Test_Repair_Vehicles_Works_Correctly()
        {
            garage.AddVehicle(new Vehicle("BMW", "E46", "B6996TX"));
            garage.AddVehicle(new Vehicle("Mercedes", "S65", "B6969TX"));
            garage.AddVehicle(new Vehicle("BMW", "E38", "B7038TX"));
            garage.AddVehicle(new Vehicle("BMW", "E39", "B3298TX"));
            garage.AddVehicle(new Vehicle("Mitsubishi", "Galant", "B2018TX"));
            garage.AddVehicle(new Vehicle("Audi", "80", "B1232TX"));
            garage.AddVehicle(new Vehicle("Seat", "Ibiza", "B7068TX"));
            garage.AddVehicle(new Vehicle("Audi", "A3", "B3456TX"));
            garage.AddVehicle(new Vehicle("Golf", "4", "B1234TX"));
            garage.AddVehicle(new Vehicle("Honda", "Civic", "B0889TX"));
            garage.DriveVehicle("B6996TX", 45, true);
            garage.DriveVehicle("B1232TX", 65, true);
            garage.DriveVehicle("B1234TX", 30, true);
            garage.DriveVehicle("B3456TX", 30, true);
            Assert.AreEqual(4, garage.Vehicles.FindAll(v=>v.IsDamaged == true).Count);
            Assert.AreEqual($"Vehicles repaired: 4",garage.RepairVehicles());
            Assert.AreEqual(0, garage.Vehicles.FindAll(v => v.IsDamaged == true).Count);
            Assert.IsTrue(garage.Vehicles.All(v=>v.IsDamaged == false));
        }
    }
}


