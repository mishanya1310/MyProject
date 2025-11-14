using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private ITransactionsService _transactionsService;
        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _transactionsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _transactionsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Транзакции transactions)
        {
            await _transactionsService.Create(transactions);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Транзакции transactions)
        {
            await _transactionsService.Update(transactions);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _transactionsService.Delete(id);
            return Ok();
        }
    }
}