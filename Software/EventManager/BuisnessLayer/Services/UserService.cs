using DataAccessLayer.Interfaces;
using DataAccessLayer.Iznimke;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class UserService
    {
        /* OLD CODE
        public bool RegisterUser(User user)
        {
            bool IsSuccesfull = false;

            using (var repo = new UserRepository())
            {
                int affectedRows = repo.Add(user);
                IsSuccesfull = affectedRows > 0;
            }
            return IsSuccesfull;
        }

        public async Task<User> LoginUser(string username, string password)
        {
            using (var repo = new UserRepository())
            {
                return await repo.Login(username, password);
            }
        }


        public bool UpdateUser(User user)
        {
            bool IsSuccesfull = false;

            using (var repo = new UserRepository())
            {
                int affectedRows = repo.Update(user);
                IsSuccesfull = affectedRows > 0;
            }
            return IsSuccesfull;
        }

        public User GetUserById(User user)
        {
            using (var repo = new UserRepository())
            {
                return repo.GetById(user);
            }
        }
        */
        private readonly IUserRepository _userRepository;

        
        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public bool RegisterUser(User user)
        {
            int affectedRows = _userRepository.Add(user);
            return affectedRows > 0;
        }

        public async Task<User> LoginUser(string username, string password)
        {
            return await _userRepository.Login(username, password);
        }

        public bool UpdateUser(User user)
        {
            int affectedRows = _userRepository.Update(user);
            return affectedRows > 0;
        }

        public int RemoveUser(User user)
        {
            return _userRepository.Remove(user);
        }

        public User GetUserById(User user)
        {
            return _userRepository.GetById(user);
        }
    }
}
