namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        [Test]
        public void TakePhoto_EnoughMemory_ReturnsTrue()
        {
            // Arrange
            Device device = new Device(100);

            // Act
            bool result = device.TakePhoto(20);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, device.Photos);
        }

        [Test]
        public void TakePhoto_NotEnoughMemory_ReturnsFalse()
        {
            // Arrange
            Device device = new Device(100);

            // Act
            bool result = device.TakePhoto(120);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0, device.Photos);
        }

        [Test]
        public void InstallApp_EnoughMemory_ReturnsSuccessMessage()
        {
            // Arrange
            Device device = new Device(100);

            // Act
            string result = device.InstallApp("App1", 30);

            // Assert
            Assert.AreEqual("App1 is installed successfully. Run application?", result);
            Assert.Contains("App1", device.Applications);
        }

        [Test]
        public void InstallApp_NotEnoughMemory_ThrowsInvalidOperationException()
        {
            // Arrange
            Device device = new Device(100);

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => device.InstallApp("App1", 120));
        }

        [Test]
        public void FormatDevice_ResetsProperties()
        {
            // Arrange
            Device device = new Device(100);
            device.TakePhoto(20);
            device.InstallApp("App1", 30);

            // Act
            device.FormatDevice();

            // Assert
            Assert.AreEqual(0, device.Photos);
            Assert.IsEmpty(device.Applications);
            Assert.AreEqual(device.MemoryCapacity, device.AvailableMemory);
        }

        [Test]
        public void GetDeviceStatus_ReturnsFormattedStatusString()
        {
            // Arrange
            Device device = new Device(100);
            device.TakePhoto(20);
            device.InstallApp("App1", 30);

            // Act
            string status = device.GetDeviceStatus();

            // Assert
            StringAssert.Contains("Memory Capacity: 100 MB, Available Memory: 50 MB", status);
            StringAssert.Contains("Photos Count: 1", status);
            StringAssert.Contains("Applications Installed: App1", status);
        }
    }
}