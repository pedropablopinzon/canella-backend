using backend_canella.Contexts;
using backend_canella.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend_canella.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ConexionSQLServer context;
        public BrandsController(ConexionSQLServer context)
        {
            this.context = context;
        }

        // GET: api/<BrandsController>
        [HttpGet]
        public IEnumerable<Brands> Get()
        {
            return context.Brands.ToList();
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public Brands Get(int id)
        {

            var row = context.Brands.Where(a => a.id == id).Single();
            return row;
        
        }

        // POST api/<BrandsController>
        [HttpPost]
        public async Task<Brands> PostAsync([FromBody] Brands _object)    
        {
            var obj = await context.Brands.AddAsync(_object);
            context.SaveChanges();
            return obj.Entity;
        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        public Brands Put(int id, [FromBody] Brands _object)
        {
            var DataList = context.Brands.Where(x => x.id == id).ToList();
            foreach (var item in DataList)
            {
                _object.id = item.id;
                item.name = _object.name;
                context.Brands.Update(item);
                context.SaveChanges(true);
            }
            return _object;


        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var DataList = context.Brands.Where(x => x.id == id).ToList();
            foreach (var item in DataList)
            {
                context.Brands.Remove(item);
                context.SaveChanges(true);
            }
            return true;
        }
    }
}
