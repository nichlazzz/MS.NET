using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoraunt.Restoraunt.BL.Auth.Entities;

namespace Restoraunt.Restoraunt.DataAccess
{
    public class Test
    {
        public void test(IDbContextFactory<RestorauntDbContext> contextFactory)
        {
            using var context = contextFactory.CreateDbContext();
            context.Users.Add(new UserModel() { });
            context.Users.Where(x=> x.Id == new Guid("1"));
            context.SaveChanges(); 
        }
    }
}
