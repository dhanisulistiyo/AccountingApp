﻿using MyIdentity.Entities;
using MyIdentity.Repositories;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MyIdentity.EntityFramework.Repositories
{
    internal class RoleRepository : Repository<Role>, IRoleRepository
    {
        internal RoleRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public Role FindByName(string roleName)
        {
            return Set.FirstOrDefault(x => x.RoleName == roleName);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return Set.FirstOrDefaultAsync(x => x.RoleName == roleName);
        }

        public Task<Role> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        {
            return Set.FirstOrDefaultAsync(x => x.RoleName == roleName, cancellationToken);
        }
    }
}