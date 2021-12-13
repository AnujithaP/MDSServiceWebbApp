using MDSService;
using MDSServiceWebbApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDSServiceWebbApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        private readonly IMDSServices _service;

        public TestController(IMDSServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Test()
        {

            return await _service.GetPrincipals();
        }
    }
}
