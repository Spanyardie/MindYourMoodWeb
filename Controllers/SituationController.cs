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
            var situation = await _unitOfWork.SituationRepository.GetItemAsync(Id);
            if (situation == null) return NotFound("Could not find requested Situation");


            _unitOfWork.SituationRepository.RemoveItem(situation);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<SituationDto>(situation));

            return BadRequest("Unable to remove Situation");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createsituation/{userId}")]
        public async Task<ActionResult<SituationDto>> CreateSituation(int userId, CreateSituationDto createSituationDto)
        {
            var situation = new Situation
            {
                ThoughtRecord = _mapper.Map<ThoughtRecord>(await _unitOfWork.ThoughtRecordRepository.GetItemAsync(userId)),
                What = createSituationDto.What,
                When = createSituationDto.When,
                Where = createSituationDto.Where,
                Who = createSituationDto.Who
            };

            _unitOfWork.SituationRepository.AddItem(situation);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<SituationDto>(situation));

            return BadRequest("Unable to create Situation");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getsituations/{thoughtRecordId}")]
        public async Task<ActionResult<IEnumerable<SituationDto>>> GetSituationsForThoughtRecord(int thoughtRecordId)
        {
            var situations = await _unitOfWork.SituationRepository.GetItemsAsync(tr => tr.ThoughtRecord.Id == thoughtRecordId);
            if (situations == null) return NotFound("There are no Situations stored");

            return Ok(situations);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getsituation/{situationId}")]
        public async Task<ActionResult<SituationDto>> GetSituationById(int situationId)
        {
            var situation = await _unitOfWork.SituationRepository.GetItemAsync(situationId);
            if (situation == null) return BadRequest("Situation with specified Id does not exist");

            return Ok(_mapper.Map<SituationDto>(situation));
        }
    }
}
