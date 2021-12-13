using MDSServiceWebbApp.Models.SQL;
using System.Collections.Generic;

namespace MDSServiceWebbApp.Services
{
    public interface ISqlDataService
    {
        bool Any();
        IEnumerable<MDSSqlData> GetMDSSqlData();
        MDSSqlData GetMDSSqlData(int id);
        void Seed(IEnumerable<MDSSqlData> seed);
    }
}
