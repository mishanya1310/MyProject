using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskProfileController : ControllerBase
    {
        private IRiskProfileService _RiskProfileService;
        public RiskProfileController(IRiskProfileService RiskProfileService)
        {
            _RiskProfileService = RiskProfileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _RiskProfileService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _RiskProfileService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ПрофилиРиска riskProfile)
        {
            await _RiskProfileService.Create(riskProfile);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ПрофилиРиска riskProfile)
        {
            await _RiskProfileService.Update(riskProfile);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _RiskProfileService.Delete(id);
            return Ok();
        }
    }
}