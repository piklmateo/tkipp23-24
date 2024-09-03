using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface ITransactionRepository
    {
        IQueryable<Transaction> GetTransactionsByUser(User user);
        IQueryable<Transaction> GetAllTransactions();
        IQueryable<Transaction> GetTransactionsEvent(Event events);

        int Add(Transaction entity, bool saveChanges = true);
    }
}
