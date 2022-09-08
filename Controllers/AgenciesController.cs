using backend_canella.Contexts;
using backend_canella.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend_canella.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciesController : ControllerBase
    {
        private readonly ConexionSQLServer context;
        public AgenciesController(ConexionSQLServer context)
        {
            this.context = context;
        }

        // GET: api/<AgenciesController>
        [HttpGet]
        public IEnumerable<Agencies> Get()
        {
            return context.Agencies.ToList();
        }

        // GET api/<AgenciesController>/5
        [HttpGet("{id}")]
        public Agencies Get(int id)
        {

            var row = context.Agencies.Where(a => a.id == id).Single();
            return row;
        
        }

        // POST api/<AgenciesController>
        [HttpPost]
        public async Task<Agencies> PostAsync([FromBody] Agencies _object)    
        {
            var obj = await context.Agencies.AddAsync(_object);
            context.SaveChanges();
            return obj.Entity;
        }

        // PUT api/<AgenciesController>/5
        [HttpPut("{id}")]
        public Agencies Put(int id, [FromBody] Agencies _object)
        {
            var DataList = context.Agencies.Where(x => x.id == id).ToList();
            foreach (var item in DataList)
            {
                _object.id = item.id;
                item.name = _object.name;
                item.phone = _object.phone;
                item.address = _object.address;
                item.webUrl = _object.webUrl;
                context.Agencies.Update(item);
                context.SaveChanges(true);
            }
            return _object;


        }

        // DELETE api/<AgenciesController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var DataList = context.Agencies.Where(x => x.id == id).ToList();
            foreach (var item in DataList)
            {
                context.Agencies.Remove(item);
                context.SaveChanges(true);
            }
            return true;
        }
    }
}
