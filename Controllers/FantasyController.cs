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
    public class FantasyController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FantasyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removefantasy/{Id}")]
        public async Task<ActionResult<FantasyDto>> RemoveFantasy(int Id)
        {
            var fantasy = await _unitOfWork.FantasyRepository.GetFantasyAsync(Id);
            if (fantasy == null) return NotFound("Could not find requested Fantasy");


            _unitOfWork.FantasyRepository.RemoveFantasy(fantasy);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<FantasyDto>(fantasy));

            return BadRequest("Unable to remove Fantasy");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createfantasy/{userId}")]
        public async Task<ActionResult<FantasyDto>> CreateFantasy(int userId, CreateFantasyDto createFantasyDto)
        {
            var fantasy = new Fantasy
            {
                ActionOf = createFantasyDto.ActionOf,
                DoAction = (IPlanAction.ActionType)createFantasyDto.DoAction,
                Strength = createFantasyDto.Strength,
                ToWhat = createFantasyDto.ToWhat,
                Type = (IPlanAction.ReactionType)createFantasyDto.Type,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.FantasyRepository.AddFantasy(fantasy);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<FantasyDto>(fantasy));

            return BadRequest("Unable to create Fantasy");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getfantasies/{userId}")]
        public async Task<ActionResult<IEnumerable<FantasyDto>>> GetFantasiesForUser(int userId)
        {
            var fantasies = await _unitOfWork.FantasyRepository.GetFantasiesAsync(userId);
            if (fantasies == null) return NotFound("There are no Fantasies stored");

            return Ok(fantasies);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getfantasy/{fantasyId}")]
        public async Task<ActionResult<FantasyDto>> GetFantasyById(int fantasyId)
        {
            var fantasy = await _unitOfWork.FantasyRepository.GetFantasyAsync(fantasyId);
            if (fantasy == null) return BadRequest("Fantasy with specified Id does not exist");

            return Ok(_mapper.Map<FantasyDto>(fantasy));
        }

    }
}
