using MDSService;
using MDSServiceWebbApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDSServiceWebbApp.Services
{
    public interface IMDSServices
    {
        public Task<IEnumerable<MDSServiceWebbApp.Models.Organisation>> GetOrganisations();
        public Task<IEnumerable<Person>> GetPersoner();
        public Task<IEnumerable<Medarbetare>> GetCoWorkers();
        public Task<Medarbetare> GetCoWorker(string coworkerId);
        public Task<Medarbetare> AddCoworker(Medarbetare medarbetare);
        public Task<Person> GetPerson(Guid personId);
        public Task<bool> CheckPerson(string name);
        public Task<Person> AddPerson(Person person);
        public Task UpdatePerson(Person person);

        public Task<IEnumerable<User>> GetPermissions(string entityName, PermissionType permissionType, AccessPermissionType accessPermissionType);
        public Task<IEnumerable<User>> GetPrincipals();

        public int GetLastError();
    }
}
