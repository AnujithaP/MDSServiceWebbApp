using MDSServiceWebbApp.Models.SQL;
using Microsoft.EntityFrameworkCore;

namespace MDSServiceWebbApp.Data
{
    public class MDSDbContext : DbContext
    {
        public MDSDbContext(DbContextOptions<MDSDbContext> options) : base(options)
        {

        }

        public DbSet<MDSSqlData> MDSSqlDatas { get; set; }
    }
}
