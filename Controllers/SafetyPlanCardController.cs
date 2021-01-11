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
    public class SafetyPlanCardController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SafetyPlanCardController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removesafetyplancard/{Id}")]
        public async Task<ActionResult<SafetyPlanCardDto>> RemoveSafetyPlanCard(int Id)
        {
            var safetyPlanCard = await _unitOfWork.SafetyPlanCardRepository.GetItemAsync(Id);
            if (safetyPlanCard == null) return NotFound("Could not find requested Safety Plan Card");

            _unitOfWork.SafetyPlanCardRepository.RemoveItem(safetyPlanCard);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<SafetyPlanCardDto>(safetyPlanCard));

            return BadRequest("Unable to remove Safety Plan Card");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createsafetyplancard/{userId}")]
        public async Task<ActionResult<SafetyPlanCardDto>> CreateSafetyPlanCard(int userId, CreateSafetyPlanCardDto createSafetyPlanCardDto)
        {
            var safetyPlanCard = new SafetyPlanCard
            {
                CalmMyself = createSafetyPlanCardDto.CalmMyself,
                TellMyself = createSafetyPlanCardDto.TellMyself,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId),
                WillCall = createSafetyPlanCardDto.WillCall,
                WillGoTo = createSafetyPlanCardDto.WillGoTo
            };

            _unitOfWork.SafetyPlanCardRepository.AddItem(safetyPlanCard);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<SafetyPlanCardDto>(safetyPlanCard));

            return BadRequest("Unable to create Safety Plan Card");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getsafetyplancards/{userId}")]
        public async Task<ActionResult<IEnumerable<SafetyPlanCardDto>>> GetSafetyPlanCardsForThoughtRecord(int userId)
        {
            var safetyPlanCards = await _unitOfWork.SafetyPlanCardRepository.GetItemsAsync(u => u.User.Id == userId);
            if (safetyPlanCards == null) return NotFound("There are no Safety Plan Cards stored");

            return Ok(safetyPlanCards);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getsafetyplancard/{safetyPlanCardId}")]
        public async Task<ActionResult<SafetyPlanCardDto>> GetSafetyPlanCardById(int safetyPlanCardId)
        {
            var safetyPlanCard = await _unitOfWork.SafetyPlanCardRepository.GetItemAsync(safetyPlanCardId);
            if (safetyPlanCard == null) return BadRequest("Safety Plan Card with specified Id does not exist");

            return Ok(_mapper.Map<SafetyPlanCardDto>(safetyPlanCard));
        }
    }
}
