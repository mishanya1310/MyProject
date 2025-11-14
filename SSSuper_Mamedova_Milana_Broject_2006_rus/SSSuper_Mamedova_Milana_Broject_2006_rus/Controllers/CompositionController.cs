using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompositionController : ControllerBase
    {
        private ICompositionService _CompositionService;
        public CompositionController(ICompositionService CompositionService)
        {
            _CompositionService = CompositionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _CompositionService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _CompositionService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(СоставПортфеля composition)
        {
            await _CompositionService.Create(composition);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(СоставПортфеля composition)
        {
            await _CompositionService.Update(composition);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _CompositionService.Delete(id);
            return Ok();
        }
    }
}