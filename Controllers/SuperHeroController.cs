using Dapper;
using Dapper_CRUD_ASP.Net_core_SQL_Server.Infrastructure.IGeneric;
using Dapper_CRUD_ASP.Net_core_SQL_Server.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Dapper_CRUD_ASP.Net_core_SQL_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHero<SuperHero> _repo;

        public SuperHeroController(ISuperHero<SuperHero> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSuperHeroes()
        {
            var _list = await _repo.GetAllAsync();
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] SuperHero SH)
        {
            var _result = await _repo.CreateAsync(SH);
            return Ok(_result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] SuperHero SH, int id)
        {
            var _result = await _repo.UpdateAsync(SH, id);
            return Ok(_result);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var _result = await _repo.DeleteAsync(id);
            return Ok(_result);
        }
    }
}
