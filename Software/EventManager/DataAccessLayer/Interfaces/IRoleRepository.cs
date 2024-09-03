using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetAll();
        int Update(Role role, bool saveChanges = true);
    }
}
