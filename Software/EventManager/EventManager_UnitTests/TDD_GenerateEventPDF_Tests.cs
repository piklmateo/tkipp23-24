using BuisnessLayer.HelperClasses;
using DataAccessLayer.Interfaces;
using EntitiesLayer.Entities;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace EventManager_UnitTests
{
    public class TDD_GenerateEventPDF_Tests
    {
        [Fact]
        public void GenerateEventPDF_WhenGivenEventAndCalled_ReturnsTrue()
        {
            // Arrange
            var generator = new GenerateEventPDF();
            var newEvent = new Event { Name = "Sample Event" };

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "event.pdf");
            generator.SetFilePath(filePath);

            // Act
            bool result = generator.GenerateNewEventPDF(newEvent);

            // Assert
            Assert.True(result);

            // Cleanup
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        [Fact]
        public void GenerateEventPDF_OnEmptyEvent_ReturnsFalse()
        {
            // Arrange
            var generator = new GenerateEventPDF();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "event.pdf");
            generator.SetFilePath(filePath);
            Event testEvent = new Event();

            // Act
            bool result = generator.GenerateNewEventPDF(testEvent);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GenerateNewEventPDF_WhenEventIsNull_ReturnFalse()
        {
            // Arrange
            var generator = new GenerateEventPDF();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "event.pdf");
            generator.SetFilePath(filePath);

            // Act
            bool result = generator.GenerateNewEventPDF(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GenerateNewEventPDF_WhenEventIsValid_ShouldCreatePDF()
        {
            // Arrange
            var generator = new GenerateEventPDF();
            var newEvent = new Event { Name = "Sample Event" };

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "event.pdf");
            generator.SetFilePath(filePath);

            // Act
            bool result = generator.GenerateNewEventPDF(newEvent);

            // Assert
            Assert.True(result);
            Assert.True(File.Exists(filePath));

            // Cleanup
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        [Fact]
        public void GenerateNewEventPDF_WhenInvalidFilePath_ReturnFalse()
        {
            // Arrange
            var generator = new GenerateEventPDF();
            var newEvent = new Event { Name = "Sample Event" };

            string originalDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Environment.SetEnvironmentVariable("USERPROFILE", "Z:\\InvalidPath");

            // Act
            bool result = generator.GenerateNewEventPDF(newEvent);

            // Assert
            Assert.False(result);

            // Cleanup
            Environment.SetEnvironmentVariable("USERPROFILE", originalDesktopPath);
        }

        [Fact]
        public void SetFilePath_WhenFilePathIsNull_ShouldReturnFalse()
        {
            // Arrange
            var generator = new GenerateEventPDF();

            // Act
            bool result = generator.SetFilePath(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GenerateEventPDF_WhenGivenEventWithStartTimeAndCalled_ReturnsTrue()
        {
            // Arrange
            var generator = new GenerateEventPDF();
            var newEvent = new Event { Name = "Sample Event", StartTime = new TimeSpan(0, 22, 35, 33)};

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "event.pdf");
            generator.SetFilePath(filePath);

            // Act
            bool result = generator.GenerateNewEventPDF(newEvent);

            // Assert
            Assert.True(result);

            // Cleanup
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        [Fact]
        public void GenerateEventPDF_WhenGivenEventWithImgUrlAndCalled_ReturnsTrue()
        {
            // Arrange
            var generator = new GenerateEventPDF();
            var newEvent = new Event { Name = "Sample Event", imgUrl="test.com" };

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "event.pdf");
            generator.SetFilePath(filePath);

            // Act
            bool result = generator.GenerateNewEventPDF(newEvent);

            // Assert
            Assert.True(result);

            // Cleanup
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

    }
}
