using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfoliosController : ControllerBase
    {
        private IPortfoliosService _portfoliosService;
        public PortfoliosController(IPortfoliosService portfoliosService)
        {
            _portfoliosService = portfoliosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _portfoliosService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _portfoliosService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Портфели portfolios)
        {
            await _portfoliosService.Create(portfolios);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Портфели portfolios)
        {
            await _portfoliosService.Update(portfolios);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _portfoliosService.Delete(id);
            return Ok();
        }
    }
}