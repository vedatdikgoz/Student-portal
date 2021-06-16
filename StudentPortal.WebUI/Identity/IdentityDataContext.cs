using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace StudentPortal.WebUI.Identity
{
    public class IdentityDataContext:IdentityDbContext<User,IdentityRole,string>
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options): base(options)
        {
            
        }
    }
}
