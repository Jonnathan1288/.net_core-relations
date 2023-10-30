using Api_Entity_Relations.Context;
using Api_Entity_Relations.Models;
using Api_Entity_Relations.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Entity_Relations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        //private readonly PrincipalContext _principalContext;
        private readonly IRepository<Parent> _repository;

        public ParentController(IRepository<Parent> repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Parent>> findAll() 
        {
            return await _repository.findAll();
        }

        [HttpPost]
        public async Task<Parent> save(Parent p) {
            return await _repository.save(p);
        }

        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Child>>> findAllChild()
        {
            var response = await _principalContext.Childrens.Include(c => c.Parent).ToListAsync();
            //return await _principalContext.Childrens.ToListAsync();
            return response;
        }*/
    }
}
