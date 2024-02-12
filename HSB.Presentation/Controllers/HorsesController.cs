using HSB.Application.Dtos;
using HSB.Application.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HSB.Presentation.Controllers
{
	public class HorsesController : BaseController
	{
		private readonly IServiceManager _serviceManager;
		public HorsesController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[HttpGet(Name = "GetHorses")]
		public async Task<IActionResult> GetHorses()
		{
			var horses = await _serviceManager.HorseService.GetAllHorsesAsync(trackChanges: false);

			return Ok(horses);
		}

		[HttpGet("{id:guid}", Name = "GetHorse")]
		public async Task<IActionResult> GetHorse(Guid Id)
		{
			var horse = await _serviceManager.HorseService.GetHorseAsync(Id, trackChanges: false);

			return Ok(horse);
		}

		[HttpPost(Name = "CreateHorse")]
		public async Task<IActionResult> CreateHorse([FromBody] HorseDto horse)
		{
			if (horse is null)
				return BadRequest("HorseDto object is null.");

			if (!ModelState.IsValid)
			{
				var errorMessages = ModelState.Values.SelectMany(errs => errs.Errors).Select(err => err.ErrorMessage).ToList();
				return BadRequest(string.Join(",", errorMessages));
			}
			var createdHorse = await _serviceManager.HorseService.CreateHorseAsync(horse);

			return Ok(createdHorse);
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteHorse(Guid Id)
		{
			await _serviceManager.HorseService.DeleteHorse(Id, trackChanges: false);
			return Ok("Deleted");
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateHorse(Guid Id,[FromBody] HorseDto horse)
		{
			if (horse is null)
				return BadRequest("HorseDto object is null.");

			if (!ModelState.IsValid)
			{
				var errorMessages = ModelState.Values.SelectMany(errs => errs.Errors).Select(err => err.ErrorMessage).ToList();
				return BadRequest(string.Join(",", errorMessages));
			}

			var updatedEntity = await _serviceManager.HorseService.UpdateHorse(horse,Id,trackChanges: false);
			return Ok(updatedEntity);
		}
	}
}
