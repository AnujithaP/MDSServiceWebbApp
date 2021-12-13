using MDSServiceWebbApp.Models.Staging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDSServiceWebbApp.Services
{
    public interface IStagingService
    {
        bool Any();
        IEnumerable<Person_Leaf> GetPerson_Leaves();
        void AddPerson_Leaf(Person_Leaf person_leaf);
        void Seed(IEnumerable<Person_Leaf> leafs);
    }
}
