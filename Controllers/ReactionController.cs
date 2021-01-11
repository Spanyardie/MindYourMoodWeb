using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Controllers
{
    public class ReactionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReactionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removereaction/{Id}")]
        public async Task<ActionResult<ReactionDto>> RemoveReaction(int Id)
        {
            var reaction = await _unitOfWork.ReactionRepository.GetItemAsync(Id);
            if (reaction == null) return NotFound("Could not find requested Reaction");

            _unitOfWork.ReactionRepository.RemoveItem(reaction);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ReactionDto>(reaction));

            return BadRequest("Unable to remove Reaction");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createreaction/{userId}")]
        public async Task<ActionResult<ReactionDto>> CreateReaction(int userId, CreateReactionDto createReactionDto)
        {
            var reaction = new Reaction
            {
                ActionOf = createReactionDto.ActionOf,
                DoAction = (IPlanAction.ActionType)createReactionDto.DoAction,
                Strength = createReactionDto.Strength,
                ToWhat = createReactionDto.ToWhat,
                Type = (IPlanAction.ReactionType)createReactionDto.Type,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.ReactionRepository.AddItem(reaction);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ReactionDto>(reaction));

            return BadRequest("Unable to create Reaction");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getreactions/{userId}")]
        public async Task<ActionResult<IEnumerable<ReactionDto>>> GetReactionsForThoughtRecord(int userId)
        {
            var reactions = await _unitOfWork.ReactionRepository.GetItemsAsync(u => u.User.Id == userId);
            if (reactions == null) return NotFound("There are no Reactions stored");

            return Ok(reactions);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getreaction/{reactionId}")]
        public async Task<ActionResult<ReactionDto>> GetReactionById(int reactionId)
        {
            var reaction = await _unitOfWork.ReactionRepository.GetItemAsync(reactionId);
            if (reaction == null) return BadRequest("Reaction with specified Id does not exist");

            return Ok(_mapper.Map<ReactionDto>(reaction));
        }
    }
}
