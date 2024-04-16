namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class DeviceTests
    {
        private Device device;

        [SetUp]
        public void SetUp()
        {
            device = new Device(1000);
        }

        [Test]
        public void Test_Device_Constructor_Works_Correctly()
        {
            Assert.AreEqual(1000, device.AvailableMemory);
            Assert.AreEqual(1000, device.MemoryCapacity);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [Test]
        public void Test_Device_TakePhoto_Method_Should_Work_Correctly()
        {
            device.TakePhoto(20);
            bool result = device.TakePhoto(70);
            Assert.AreEqual(2,device.Photos);
            Assert.AreEqual(910,device.AvailableMemory);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Device_TakePhoto_Method_Should_Return_False_When_Out_Of_Memory()
        {
            Assert.IsFalse(device.TakePhoto(device.MemoryCapacity+204));
            Assert.AreEqual(0,device.Photos);
        }

        [Test]
        public void Test_Device_InstallApp_Method_Works_Correctly()
        {
            string output = device.InstallApp("Facebook", 100);
            Assert.AreEqual(900,device.AvailableMemory);
            Assert.AreEqual($"Facebook is installed successfully. Run application?",output);
        }

        [Test]
        public void Test_Device_InstallApp_Method_Should_Throw_Exception_When_Out_Of_Memory()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                device.InstallApp("Call Of Duty",device.MemoryCapacity+1024));
            Assert.AreEqual($"Not enough available memory to install the app.",exception.Message);
        }
        [Test]
        public void Test_Format_Device_Method_Should_Work_Correctly()
        {
            device.TakePhoto(10);
            device.InstallApp("Facebook", 100);
            device.FormatDevice();
            Assert.AreEqual(1000,device.AvailableMemory);
            Assert.AreEqual(1000,device.MemoryCapacity);
            Assert.AreEqual(0,device.Photos);
            Assert.AreEqual(0,device.Applications.Count);
        }

        [Test]
        public void Test_Device_Status_Works_Properly()
        {
            device.TakePhoto(10);
            device.TakePhoto(10);
            device.TakePhoto(10);
            device.TakePhoto(10);
            device.TakePhoto(10);
            device.InstallApp("Call Of Duty", 300);
            device.InstallApp("Subway surfers", 200);
            string output =
                $"Memory Capacity: 1000 MB, Available Memory: 450 MB{Environment.NewLine}Photos Count: 5{Environment.NewLine}Applications Installed: Call Of Duty, Subway surfers";
            Assert.AreEqual(output,device.GetDeviceStatus());
        }
    }
}