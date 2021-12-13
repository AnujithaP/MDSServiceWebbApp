using MDSServiceWebbApp.Models;
using MDSServiceWebbApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDSServiceWebbApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MedarbetarEntityController : Controller
    {
        private readonly IMDSServices _service;

        public MedarbetarEntityController(IMDSServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Medarbetare>> MedarbetareLista()
        {
            return await _service.GetCoWorkers();
        }

        [HttpGet("{id}")]
        public async Task<Medarbetare> Medarbetare(string id)
        {
            return await _service.GetCoWorker(id);
        }

        [HttpPost]
        public async Task<Medarbetare> AddMedarbetare([FromBody]Medarbetare medarbetare )
        {
            return await _service.AddCoworker(medarbetare);
        }
    }
}
