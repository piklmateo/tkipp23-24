using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class RoleService
    {
        private readonly IRoleRepository _repo;

        public RoleService(IRoleRepository repository)
        {
            _repo = repository;
        }

        public List<Role> GetRoles()
        {
            return _repo.GetAll().ToList();
        }

        public bool Update(Role role)
        {
            int affectedRows = _repo.Update(role);
            return affectedRows > 0;
        }
    }
}
