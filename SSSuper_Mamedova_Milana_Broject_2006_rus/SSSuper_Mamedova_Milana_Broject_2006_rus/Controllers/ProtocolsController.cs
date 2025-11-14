using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtocolsController : ControllerBase
    {
        private IProtocolsService _protocolsService;
        public ProtocolsController(IProtocolsService protocolsService)
        {
            _protocolsService = protocolsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _protocolsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _protocolsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ПротоколыСтейкинг protocols)
        {
            await _protocolsService.Create(protocols);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ПротоколыСтейкинг protocols)
        {
            await _protocolsService.Update(protocols);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _protocolsService.Delete(id);
            return Ok();
        }
    }
}