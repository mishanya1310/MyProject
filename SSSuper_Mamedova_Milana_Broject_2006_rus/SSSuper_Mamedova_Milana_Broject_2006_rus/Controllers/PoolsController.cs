using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoolsController : ControllerBase
    {
        private IPoolsService _poolsService;
        public PoolsController(IPoolsService poolsService)
        {
            _poolsService = poolsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _poolsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _poolsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ВалютныеПулы pools)
        {
            await _poolsService.Create(pools);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ВалютныеПулы pools)
        {
            await _poolsService.Update(pools);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _poolsService.Delete(id);
            return Ok();
        }
    }
}