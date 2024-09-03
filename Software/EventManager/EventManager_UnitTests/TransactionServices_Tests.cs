using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BuisnessLayer;
using BuisnessLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using FakeItEasy;

namespace EventManager_UnitTests
{
    public class TransactionServices_Tests
    {
        [Fact]
        public void GetAllTransactions_GivenListOfTransactions_ReturnsListOfTransactions()
        {
            // Arrange
            var fakeRepository = A.Fake<ITransactionRepository>();
            var transactionService = new TransactionServices(fakeRepository);
            var expectedTransaction = new List<Transaction>
            {
                new Transaction { Id = 1, Type = "Music", Amount = 2, Id_Users = 1, Id_Events = 1 },
                new Transaction { Id = 1, Type = "Music", Amount = 1, Id_Users = 1 , Id_Events = 2 }
            };
            A.CallTo(() => fakeRepository.GetAllTransactions()).Returns(expectedTransaction.AsQueryable());

            // Act
            var result = transactionService.GetAllTransactions();

            // Assert
            Assert.Equal(expectedTransaction.Count, result.Count);
            Assert.Equal(expectedTransaction, result);
        }

        [Fact]
        public void GetAllTransactions_GivenNoTransactions_ReturnsEmptyList()
        {
            // Arrange
            var fakeRepository = A.Fake<ITransactionRepository>();
            var expectedTransactions = new List<Transaction>().AsQueryable();

            A.CallTo(() => fakeRepository.GetAllTransactions()).Returns(expectedTransactions);

            var service = new TransactionServices(fakeRepository);

            // Act
            var result = service.GetAllTransactions();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetTransactionsEvent_GivenListOfTransactionsAndEventId_ReturnTransactionsOfEvent()
        {
            // Arrange
            var fakeRepository = A.Fake<ITransactionRepository>();
            var events = new Event { Id = 1 };
            var expectedEvent = new List<Transaction>
            {
               new Transaction { Id = 1, Type = "Music", Amount = 2, Id_Users = 1, Id_Events = 1 },
               new Transaction { Id = 2, Type = "Music", Amount = 1, Id_Users = 1 , Id_Events = 2 }
            }.AsQueryable();

            A.CallTo(() => fakeRepository.GetTransactionsEvent(events)).Returns(expectedEvent);

            var service = new TransactionServices(fakeRepository);
            // Act
            var result = service.GetTransactionsEvent(events);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedEvent.Count(), result.Count);
            Assert.Equal(expectedEvent, result);
        }

        [Fact]
        public void GetTransactionsEvent_GivenNoTransactions_ReturnsEmptyList_()
        {
            // Arrange
            var fakeRepository = A.Fake<ITransactionRepository>();
            var events = new Event { Id = 1 };
            var expectedTransactions = new List<Transaction>().AsQueryable();

            A.CallTo(() => fakeRepository.GetTransactionsEvent(events)).Returns(expectedTransactions);

            var service = new TransactionServices(fakeRepository);

            // Act
            var result = service.GetTransactionsEvent(events);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
