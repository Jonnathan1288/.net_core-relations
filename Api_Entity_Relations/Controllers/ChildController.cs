using Api_Entity_Relations.Models;
using Api_Entity_Relations.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Entity_Relations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IRepository<Child> _repository;

        public ChildController(IRepository<Child> repository) {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Child>> findAll() {
            return await _repository.findAll();
        }

        [HttpPost]
        public async Task<Child> save(Child e) {
            return await _repository.save(e);
        }
    }
}
