using MDSService;
using MDSServiceWebbApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDSServiceWebbApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class Authenticate : Controller
    {
        private readonly IMDSServices _service;

        public IEnumerable<User> MDSUsers { get; set; }

        public Authenticate(IMDSServices service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IEnumerable<User>> Get()
        {
            StringValues accountName;

            MDSUsers = await _service.GetPrincipals();

            if (HttpContext.Request.Headers.ContainsKey("accountName"))
            {
                HttpContext.Request.Headers.TryGetValue("accountName", out accountName);

                var account = MDSUsers.Where(u => u.Identifier.Name == accountName).FirstOrDefault();
            }

            return MDSUsers;
        }
    }
}
