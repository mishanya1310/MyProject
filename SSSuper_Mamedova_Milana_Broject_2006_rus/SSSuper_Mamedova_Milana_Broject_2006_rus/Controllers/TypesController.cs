using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private ITypesService _typesService;
        public TypesController(ITypesService typesService)
        {
            _typesService = typesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _typesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _typesService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ТипыАктивов types)
        {
            await _typesService.Create(types);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ТипыАктивов types)
        {
            await _typesService.Update(types);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _typesService.Delete(id);
            return Ok();
        }
    }
}