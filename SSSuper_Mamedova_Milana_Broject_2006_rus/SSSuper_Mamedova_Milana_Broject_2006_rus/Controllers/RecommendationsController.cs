using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        private IRecommendationsService _recommendationsService;
        public RecommendationsController(IRecommendationsService recommendationsService)
        {
            _recommendationsService = recommendationsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _recommendationsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _recommendationsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Рекомендации recommendations)
        {
            await _recommendationsService.Create(recommendations);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Рекомендации recommendations)
        {
            await _recommendationsService.Update(recommendations);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _recommendationsService.Delete(id);
            return Ok();
        }
    }
}