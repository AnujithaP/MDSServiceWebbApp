using MDSServiceWebbApp.Models.Staging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDSServiceWebbApp.Data
{
    public class StagingContext : DbContext
    {
        public StagingContext(DbContextOptions<StagingContext> options) : base(options)
        {

        }

        public DbSet<Person_Leaf> Person_Leafs { get; set; }
    }
}
