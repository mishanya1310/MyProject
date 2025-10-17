using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveController : ControllerBase
    {
        private IActiveService _activeService;
        public ActiveController(IActiveService activeService)
        {
            _activeService = activeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _activeService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _activeService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Активы active)
        {
            await _activeService.Create(active);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Активы active)
        {
            await _activeService.Update(active);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _activeService.Delete(id);
            return Ok();
        }
    }
}