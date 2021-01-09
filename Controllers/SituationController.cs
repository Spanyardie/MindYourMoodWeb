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
    public class SituationController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SituationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removesituation/{Id}")]
        public async Task<ActionResult<SituationDto>> RemoveSituation(int Id)
        {
            var situation = await _unitOfWork.SituationRepository.GetSituationAsync(Id);
            if (situation == null) return NotFound("Could not find requested Situation");


            _unitOfWork.SituationRepository.RemoveSituation(situation);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<SituationDto>(situation));

            return BadRequest("Unable to remove Situation");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createsituation/{userId}")]
        public async Task<ActionResult<SituationDto>> CreateSituation(int userId, CreateSituationDto createSituationDto)
        {
            var situation = new Situation
            {
                ThoughtRecord = await _unitOfWork.ThoughtRecordRepository.GetThoughtRecord(userId),
                What = createSituationDto.What,
                When = createSituationDto.When,
                Where = createSituationDto.Where,
                Who = createSituationDto.Who
            };

            _unitOfWork.SituationRepository.AddSituation(situation);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<SituationDto>(situation));

            return BadRequest("Unable to create Situation");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getsituations/{userId}")]
        public async Task<ActionResult<IEnumerable<SituationDto>>> GetSituationsForUser(int userId)
        {
            var situations = await _unitOfWork.SituationRepository.GetSituationsAsync(userId);
            if (situations == null) return NotFound("There are no Situations stored");

            return Ok(situations);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getsituation/{situationId}")]
        public async Task<ActionResult<SituationDto>> GetSituationById(int situationId)
        {
            var situation = await _unitOfWork.SituationRepository.GetSituationAsync(situationId);
            if (situation == null) return BadRequest("Situation with specified Id does not exist");

            return Ok(_mapper.Map<SituationDto>(situation));
        }
    }
}
