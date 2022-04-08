using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Controllers
{
    class UserRoleController
    {
        private readonly UserRoleRepository roleRepository;

        public UserRoleController()
        {
            this.roleRepository =
                new UserRoleRepository(new stuff_shopContext());
        }

        public List<UserRole> GetRoles()
        {
            List<UserRole> items = roleRepository.Items.ToList<UserRole>();
            return items;
        }
    }
}
