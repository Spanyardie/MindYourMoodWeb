using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using MindYourMoodWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;

namespace MindYourMoodWeb.Controllers
{
    public class HealthController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HealthController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removehealth/{Id}")]
        public async Task<ActionResult<HealthDto>> RemoveHealth(int Id)
        {
            var health = await _unitOfWork.HealthRepository.GetItemAsync(Id);
            if (health == null) return NotFound("Could not find requested Health");


            _unitOfWork.HealthRepository.RemoveItem(health);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<HealthDto>(health));

            return BadRequest("Unable to remove Health");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createhealth/{userId}")]
        public async Task<ActionResult<HealthDto>> CreateHealth(int userId, CreateHealthDto createHealthDto)
        {
            var health = new Health
            {
                ActionOf = createHealthDto.ActionOf,
                DoAction = (IPlanAction.ActionType)createHealthDto.DoAction,
                Strength = createHealthDto.Strength,
                ToWhat = createHealthDto.ToWhat,
                Type = (IPlanAction.ReactionType)createHealthDto.Type,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.HealthRepository.AddItem(health);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<HealthDto>(health));

            return BadRequest("Unable to create Health");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("gethealths/{userId}")]
        public async Task<ActionResult<IEnumerable<HealthDto>>> GetHealthsForUser(int userId)
        {
            var healths = await _unitOfWork.HealthRepository.GetItemsAsync(u => u.User.Id == userId);
            if (healths == null) return NotFound("There are no Healths stored");

            return Ok(healths);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("gethealth/{healthId}")]
        public async Task<ActionResult<HealthDto>> GetHealthById(int healthId)
        {
            var health = await _unitOfWork.HealthRepository.GetItemAsync(healthId);
            if (health == null) return BadRequest("Health with specified Id does not exist");

            return Ok(_mapper.Map<HealthDto>(health));
        }
    }
}
