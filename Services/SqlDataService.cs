using MDSServiceWebbApp.Data;
using MDSServiceWebbApp.Models.SQL;
using System.Collections.Generic;
using System.Linq;

namespace MDSServiceWebbApp.Services
{
    public class SqlDataService : ISqlDataService
    {
        private readonly MDSDbContext _dbContext;

        public SqlDataService(MDSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Any()
        {
            return _dbContext.MDSSqlDatas.Any();
        }

        public IEnumerable<MDSSqlData> GetMDSSqlData()
        {
            return _dbContext.MDSSqlDatas;
        }

        public MDSSqlData GetMDSSqlData(int id)
        {
            return _dbContext.MDSSqlDatas.Where(i => i.Id == id).FirstOrDefault();
        }

        public void Seed(IEnumerable<MDSSqlData> seed)
        {
            _dbContext.MDSSqlDatas.AddRange(seed);
            _dbContext.SaveChanges();
        }
    }
}
