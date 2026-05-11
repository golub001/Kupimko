using Backend.DTO;
using Backend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AdsController:ControllerBase
    {
        private AdsService _service;
        public AdsController(AdsService service)
        {
            _service = service;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromForm] CreateAdDto dto) {
            return Ok(await _service.InsertAdAsync(dto));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted=await _service.DeleteAsync(id);

            if (deleted == false)
            {
                return NotFound();
            }
            else
                return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateAdDto dto)
        {
            var update=await  _service.UpdateAd(id, dto);
            if(update == false)
            {
                NotFound();
            }
            return Ok();
        }
    }
}
