using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services
{
    public class TransactionServices
    {///<author>Antonijo Hamzić</author>

        private readonly ITransactionRepository _repo;

        public TransactionServices(ITransactionRepository repository)
        {
            _repo = repository;
        }

        public List<Transaction> GetTransactionsByUser(User user)
        {

                List<Transaction> transactions = _repo.GetTransactionsByUser(user).ToList();
                return transactions;

        }

        public List<Transaction> GetAllTransactions()
        {

                List<Transaction> transactions = _repo.GetAllTransactions().ToList();
                return transactions;

        }

        ///<author>Toni Leo Modrić Dragičević</author>
        public List<Transaction> GetTransactionsEvent(Event events) 
        {

                List<Transaction> transactions = _repo.GetTransactionsEvent(events).ToList();
                return transactions;

        }

        public bool AddTransaction(Transaction transaction) {
            bool IsSuccesfull = false;

            using (var _repo = new TransactionRepository()) {
                int affectedRows = _repo.Add(transaction);
                IsSuccesfull = affectedRows > 0;
            }
            return IsSuccesfull;
        }
    }
}
