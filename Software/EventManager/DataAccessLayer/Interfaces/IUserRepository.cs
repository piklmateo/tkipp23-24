using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        Task<User> Login(string username, string password);
        int Add(User entity, bool saveChanges = true);
        int Update(User entity, bool saveChanges = true);
        User GetById(User entity);
        int Remove(User entity, bool saveChanges = true);
    }
}
