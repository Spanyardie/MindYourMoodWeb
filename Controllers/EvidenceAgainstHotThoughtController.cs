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
    public class EvidenceAgainstHotThoughtController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EvidenceAgainstHotThoughtController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeevidenceagainsthotthought/{Id}")]
        public async Task<ActionResult<EvidenceAgainstHotThoughtDto>> RemoveEvidenceAgainstHotThought(int Id)
        {
            var evidenceagainsthotthought = await _unitOfWork.EvidenceAgainstHotThoughtRepository.GetItemAsync(Id);
            if (evidenceagainsthotthought == null) return NotFound("Could not find requested Evidence Against Hot Thought");

            _unitOfWork.EvidenceAgainstHotThoughtRepository.RemoveItem(evidenceagainsthotthought);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<EvidenceAgainstHotThoughtDto>(evidenceagainsthotthought));

            return BadRequest("Unable to remove Evidence Against Hot Thought");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createevidenceagainsthotthought/{automaticThoughtId}")]
        public async Task<ActionResult<EvidenceAgainstHotThoughtDto>> CreateEvidenceAgainstHotThought(int automaticThoughtId, CreateEvidenceAgainstHotThoughtDto createEvidenceAgainstHotThoughtDto)
        {
            var evidenceagainsthotthought = new EvidenceAgainstHotThought
            {
                AutomaticThought = _mapper.Map<AutomaticThought>(await _unitOfWork.AutomaticThoughtRepository.GetItemAsync(automaticThoughtId)),
                Evidence = createEvidenceAgainstHotThoughtDto.Evidence,
                ThoughtRecord = _mapper.Map<ThoughtRecord>(await _unitOfWork.ThoughtRecordRepository.GetItemAsync(createEvidenceAgainstHotThoughtDto.ThoughtRecordId))
            };

            _unitOfWork.EvidenceAgainstHotThoughtRepository.AddItem(evidenceagainsthotthought);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<EvidenceAgainstHotThoughtDto>(evidenceagainsthotthought));

            return BadRequest("Unable to create Evidence Against Hot Thought");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getevidenceagainsthotthoughts/{automaticThoughtId}")]
        public async Task<ActionResult<IEnumerable<EvidenceAgainstHotThoughtDto>>> GetEvidenceAgainstHotThoughtsForUser(int automaticThoughtId)
        {
            var evidenceagainsthotthoughts = await _unitOfWork.EvidenceAgainstHotThoughtRepository.GetItemsAsync(at => at.AutomaticThought.Id == automaticThoughtId);
            if (evidenceagainsthotthoughts == null) return NotFound("There are no Evidences Against Hot Thoughts stored");

            return Ok(evidenceagainsthotthoughts);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getevidenceagainsthotthought/{evidenceagainsthotthoughtId}")]
        public async Task<ActionResult<EvidenceAgainstHotThoughtDto>> GetEvidenceAgainstHotThoughtById(int evidenceagainsthotthoughtId)
        {
            var evidenceagainsthotthought = await _unitOfWork.EvidenceAgainstHotThoughtRepository.GetItemAsync(evidenceagainsthotthoughtId);
            if (evidenceagainsthotthought == null) return BadRequest("Evidence Against Hot Thought with specified Id does not exist");

            return Ok(_mapper.Map<EvidenceAgainstHotThoughtDto>(evidenceagainsthotthought));
        }
    }
}
