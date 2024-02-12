using HSB.Application.Dtos;
using HSB.Application.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HSB.Presentation.Controllers
{
	public class BattlesController : BaseController
	{
		private readonly IServiceManager _serviceManager;

		public BattlesController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[HttpGet(Name ="GetBattles")]
		public async Task<IActionResult> GetBattles()
		{
			var battles = await _serviceManager.BattleService.GetBattlesAsync(true);

			return Ok(battles); 
		}

		[HttpGet("{Id:guid}", Name ="GetBattle")]
		public async Task<IActionResult> GetBattle(Guid Id)
		{
			var battle = await _serviceManager.BattleService.GetBattleAsync(Id, trackChanges:true);

			return Ok(battle);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBattle(CreationBattleDto battle)
		{
			if (battle is null)
				return BadRequest("The battle object is null");

			if (!ModelState.IsValid)
			{
				var errorMessages = ModelState.Values.SelectMany(errs => errs.Errors).Select(err => err.ErrorMessage).ToList();
				return BadRequest(string.Join(",", errorMessages));
			}

			var battleCreated = await _serviceManager.BattleService.CreateBattle(battle);

			return Ok(battleCreated);
			
		}

		[HttpDelete("{id:Guid}")]
		public async Task<IActionResult> DeleteBattle(Guid Id)
		{
			var deletedBattle = await _serviceManager.BattleService.DeleteBattle(Id, trackChanges:false);
			return Ok(deletedBattle);
		}

		[HttpPut("{id:Guid}")]
		public async Task<IActionResult> UpdateBattle(UpateBattleDto battleForUpdate, Guid Id)
		{
			if (battleForUpdate is null)
				return BadRequest("The battle object is null");

			if (!ModelState.IsValid)
			{
				var errorMessages = ModelState.Values.SelectMany(errs => errs.Errors).Select(err => err.ErrorMessage).ToList();
				return BadRequest(string.Join(",", errorMessages));
			}

			var updatedBattle = await _serviceManager.BattleService.UpdateBattle(battleForUpdate, Id, trackChanges:false);	
			return Ok(updatedBattle);
		}
	}
}
