using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer;
using BuisnessLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using FakeItEasy;

namespace EventManager_IntegrationTests
{
    public class TransactionService_IntegrationTests
    {

        [Fact]
        public void GetAllTransactions_GivenTransactionRepository_ReturnsAllTransactions()
        {
            // Arrange
            var transactionRepository = new TransactionRepository();
            var transactionService = new TransactionServices(transactionRepository);

            // Act
            var transaction = transactionService.GetAllTransactions();

            // Assert
            Assert.NotEmpty(transaction);
        }

        [Fact]
        public void GetTransactionsEvent_GivenEventId_ReturnTransactionsOfEvent()
        {
            //Arrange
            var transactionRepository = new TransactionRepository();
            var transactionService = new TransactionServices(transactionRepository);

            var events = new Event
            {
                Id = 20,
            };

            //Act
            var result = transactionService.GetTransactionsEvent(events);

            //Assert
            Assert.NotNull(result);
        }
    }
}