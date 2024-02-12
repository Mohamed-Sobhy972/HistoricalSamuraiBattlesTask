using HSB.Application.Dtos;
using HSB.Application.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HSB.Presentation.Controllers
{
	public class SamuraisController : BaseController
	{
        private readonly IServiceManager _serviceManager;
		public SamuraisController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[HttpGet(Name ="GetSamurais")]
		public async Task<IActionResult> GetSamurais()
		{
			var samurais = await _serviceManager.SamuraiService.GetSamuraisAsync(trackChanges: true);

			return Ok(samurais);
		}

		[HttpGet("{Id:guid}", Name ="GetSamurai")]
		public async Task<IActionResult> GetSamurai(Guid Id)
		{
			var samurai = await _serviceManager.SamuraiService.GetSamuraiAsync(Id, trackChanges: true);

			return Ok(samurai);
		}

		[HttpPost]
		public async Task<IActionResult> CreateSamurai([FromBody] SamuraiDto samurai)
		{
			if (samurai is null)
				return BadRequest("Samurai object is null");

			if (!ModelState.IsValid)
			{
				var errorMessages = ModelState.Values.SelectMany(errs => errs.Errors).Select(err => err.ErrorMessage).ToList();
				return BadRequest(string.Join(",", errorMessages));
			}

			var samuraiCreated = await _serviceManager.SamuraiService.CreateSamurai(samurai);

			return Ok(samuraiCreated);
		}

		[HttpDelete("{Id:Guid}")]
		public async Task<IActionResult> DeleteSamurai(Guid Id)
		{
			var deletedEntity = await _serviceManager.SamuraiService.DeleteSamurai(Id, trackChanges: false);
			return Ok(deletedEntity);
		}

		[HttpPut("{Id:Guid}")]
		public async Task<IActionResult> UpdateSamurai([FromBody] SamuraiDto samurai, Guid Id)
		{
			if (samurai is null)
				return BadRequest("Samurai object is null");

			if (!ModelState.IsValid)
			{
				var errorMessages = ModelState.Values.SelectMany(errs => errs.Errors).Select(err => err.ErrorMessage).ToList();
				return BadRequest(string.Join(",", errorMessages));
			}

			var updatedEntity = await _serviceManager.SamuraiService.UpdateSamurai(samurai, Id, trackChanges: false);
			return Ok(updatedEntity);
		}
	}
}
