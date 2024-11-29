using Backend.Dtos;
using Backend.Services.Intrerfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalController : ControllerBase
    {
        private readonly IApiService _apiService;

        public FinalController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("sucursal")]
        public async Task<IActionResult> GetSucursalAsync()
        {
            var response = await _apiService.GetSucursalAsync();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("configuraciones")]
        public async Task<IActionResult> GetAllConfiguraciones()
        {
            var response = await _apiService.GetAllConfigsAsync();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("sucursal")]
        public async Task<IActionResult> PostSucursal([FromBody] SucursalDto sucursal)
        {
            var response = await _apiService.PostSucursalAsync(sucursal);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("sucursal")]
        public async Task<IActionResult> PutSucursal([FromBody] SucursalDto sucursal)
        {
            var response = await _apiService.PutSucursalAsync(sucursal);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
