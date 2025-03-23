using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        public readonly IWalkDifficultyRepository walkDifficultyRepository;
        public readonly IMapper mapper;
        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalkDifficulties()
        {
            var walkDifficulty = await walkDifficultyRepository.GetAllAsync();
            var walkDifficultyDTO = mapper.Map<List<Models.DTO.WalkDifficulty>>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficultyAsync")]
        public async Task<IActionResult> GetWalkDifficultyAsync(Guid id)
        {
            var walkDifficulty = await walkDifficultyRepository.GetAsync(id);

            if (walkDifficulty == null)
            {
                return NotFound();
            }

            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

            return Ok(walkDifficultyDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDifficultyAsync(Models.DTO.AddWalkDifficultyRequest addWalkDifficulty)
        {
            if (!ValidateAddWalkDifficultyAsync(addWalkDifficulty))
            {
                return BadRequest(ModelState);
            }

            var walkDifficulty = new Models.Domain.WalkDifficulty
            {
                Code = addWalkDifficulty.Code,
            };

            walkDifficulty = await walkDifficultyRepository.AddAsync(walkDifficulty);

            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

            return CreatedAtAction(nameof(GetWalkDifficultyAsync), new { id = walkDifficultyDTO.Id }, walkDifficultyDTO);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkDifficultyAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateWalkDifficultyRequest updateWalkDifficulty)
        {
            if (!ValidateUpdateWalkDifficultyAsync(updateWalkDifficulty))
            {
                return BadRequest(ModelState);
            }

            var walkDifficulty = new Models.Domain.WalkDifficulty
            {
                Code = updateWalkDifficulty.Code,
            };

            walkDifficulty = await walkDifficultyRepository.UpdateAsync(id, walkDifficulty);

            if (walkDifficulty == null)
            {
                return NotFound();
            }

            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

            return Ok(walkDifficultyDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkDifficulty(Guid id)
        {
            var walkDifficulty = await walkDifficultyRepository.DeleteAsync(id);

            if (walkDifficulty == null)
            {
                return NotFound();
            }

            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

            return Ok(walkDifficultyDTO);
        }

        #region Private Methods
        private bool ValidateAddWalkDifficultyAsync(Models.DTO.AddWalkDifficultyRequest addWalkDifficulty)
        {
            if (addWalkDifficulty == null)
            {
                ModelState.AddModelError(nameof(addWalkDifficulty), $"{nameof(addWalkDifficulty)} Cannot be empty");
                return false;
            }
            if (string.IsNullOrWhiteSpace(addWalkDifficulty.Code))
            {
                ModelState.AddModelError(nameof(addWalkDifficulty.Code), $"{nameof(addWalkDifficulty.Code)} Cannot be null or WhiteSpace");
                return false;
            }
            return true;
        }

        private bool ValidateUpdateWalkDifficultyAsync(Models.DTO.UpdateWalkDifficultyRequest updateWalkDifficulty)
        {
            if (updateWalkDifficulty == null)
            {
                ModelState.AddModelError(nameof(updateWalkDifficulty), $"{nameof(updateWalkDifficulty)} Cannot be empty");
                return false;
            }
            if (string.IsNullOrWhiteSpace(updateWalkDifficulty.Code))
            {
                ModelState.AddModelError(nameof(updateWalkDifficulty.Code), $"{nameof(updateWalkDifficulty.Code)} Cannot be null or WhiteSpace");
                return false;
            }
            return true;
        }
        #endregion
    }
}
