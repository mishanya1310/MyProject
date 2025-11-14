using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceHistoryController : ControllerBase
    {
        private IPriceHistoryService _priceHistoryService;
        public PriceHistoryController(IPriceHistoryService priceHistoryService)
        {
            _priceHistoryService = priceHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _priceHistoryService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _priceHistoryService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ИсторияЦенАктивов priceHistory)
        {
            await _priceHistoryService.Create(priceHistory);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ИсторияЦенАктивов priceHistory)
        {
            await _priceHistoryService.Update(priceHistory);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _priceHistoryService.Delete(id);
            return Ok();
        }
    }
}