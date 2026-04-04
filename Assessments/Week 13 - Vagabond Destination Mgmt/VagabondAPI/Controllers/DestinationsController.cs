using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VagabondAPI.Data;
using VagabondAPI.Models;
using VagabondAPI.Repositories;
using VagabondAPI.GlobalMiddleware;
using VagabondAPI.DTO;
using VagabondAPI.Services;

namespace VagabondAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationService _service;

        public DestinationsController(IDestinationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var destinations = await _service.GetAllAsync();
            return Ok(destinations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var destination = await _service.GetByIdAsync(id);
            return Ok(destination);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DestinationDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CityName)) return BadRequest("CityName is required.");
            if (string.IsNullOrWhiteSpace(dto.Country)) return BadRequest("Country is required.");
            if (dto.Rating < 1 || dto.Rating > 5) return BadRequest("Rating must be between 1 and 5.");
            var destination = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Details), new { id = destination.ID }, destination);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DestinationDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CityName)) return BadRequest("CityName is required.");
            if (string.IsNullOrWhiteSpace(dto.Country)) return BadRequest("Country is required.");
            if (dto.Rating < 1 || dto.Rating > 5) return BadRequest("Rating must be between 1 and 5.");

            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
