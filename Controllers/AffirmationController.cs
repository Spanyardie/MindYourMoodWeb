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
    [Authorize]
    public class AffirmationController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AffirmationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeaffirmation/{Id}")]
        public async Task<ActionResult<AffirmationDto>> RemoveAffirmation(int Id)
        {
            var affirmation = await _unitOfWork.AffirmationRepository.GetAffirmationAsync(Id);
            if (affirmation == null) return NotFound("Could not find requested Affirmation");


            _unitOfWork.AffirmationRepository.RemoveAffirmation(affirmation);

            if(await _unitOfWork.Complete()) return Ok(_mapper.Map<AffirmationDto>(affirmation));

            return BadRequest("Unable to remove Affirmation");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createaffirmation/{userId}")]
        public async Task<ActionResult<AffirmationDto>> CreateAffirmation(int userId, CreateAffirmationDto createAffirmationDto)
        {
            var affirmation = new Affirmation
            {
                AffirmationText = createAffirmationDto.AffirmationText,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.AffirmationRepository.AddAffirmation(affirmation);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<AffirmationDto>(affirmation));

            return BadRequest("Unable to create Affirmation");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getaffirmations/{userId}")]
        public async Task<ActionResult<IEnumerable<AffirmationDto>>> GetAffirmationsForUser(int userId)
        {
            var affirmations = await _unitOfWork.AffirmationRepository.GetAffirmationsAsync(userId);
            if (affirmations == null) return NotFound("There are no Affirmations stored");

            return Ok(affirmations);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getaffirmation/{affirmationId}")]
        public async Task<ActionResult<AffirmationDto>> GetAffirmationById(int affirmationId)
        {
            var affirmation = await _unitOfWork.AffirmationRepository.GetAffirmationAsync(affirmationId);
            if (affirmation == null) return BadRequest("Affirmation with specified Id does not exist");

            return Ok(_mapper.Map<AffirmationDto>(affirmation));
        }
    }
}
