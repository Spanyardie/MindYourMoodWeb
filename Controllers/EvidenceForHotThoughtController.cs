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
    public class EvidenceForHotThoughtController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EvidenceForHotThoughtController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeevidenceforhotthought/{id}")]
        public async Task<ActionResult> RemoveEvidenceForHotThought(int Id)
        {
            var evidenceforhotthought = await _unitOfWork.EvidenceForHotThoughtRepository.GetItemAsync(Id);
            if (evidenceforhotthought == null) return NotFound("Could not find requested EvidenceForHotThought");


            _unitOfWork.EvidenceForHotThoughtRepository.RemoveItem(evidenceforhotthought);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<EvidenceForHotThoughtDto>(evidenceforhotthought));

            return BadRequest("Unable to remove EvidenceForHotThought");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createevidenceforhotthought/{automaticThoughtId}")]
        public async Task<ActionResult<EvidenceForHotThoughtDto>> CreateEvidenceForHotThought(int automaticThoughtId, CreateEvidenceForHotThoughtDto createEvidenceForHotThoughtDto)
        {
            var evidenceforhotthought = new EvidenceForHotThought
            {
                AutomaticThought = _mapper.Map<AutomaticThought>(await _unitOfWork.AutomaticThoughtRepository.GetItemAsync(automaticThoughtId)),
                Evidence = createEvidenceForHotThoughtDto.Evidence,
                ThoughtRecord = _mapper.Map<ThoughtRecord>(await _unitOfWork.ThoughtRecordRepository.GetItemAsync(createEvidenceForHotThoughtDto.ThoughtRecordId))
            };

            _unitOfWork.EvidenceForHotThoughtRepository.AddItem(evidenceforhotthought);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<EvidenceForHotThoughtDto>(evidenceforhotthought));

            return BadRequest("Unable to create Evidence For Hot Thought");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getevidenceforhotthoughts/{automaticThoughtId}")]
        public async Task<ActionResult<IEnumerable<EvidenceForHotThoughtDto>>> GetEvidencesForHotThought(int automaticThoughtId)
        {
            var evidenceforhotthoughts = await _unitOfWork.EvidenceForHotThoughtRepository.GetItemsAsync(at => at.AutomaticThought.Id == automaticThoughtId);
            if (evidenceforhotthoughts == null) return NotFound("There are no Evidence For Hot Thoughts stored");

            return Ok(evidenceforhotthoughts);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getevidenceforhotthought/{evidenceForHotThoughtId}")]
        public async Task<ActionResult<EvidenceForHotThoughtDto>> GetEvidenceForHotThoughtById(int evidenceForHotThoughtId)
        {
            var evidenceforhotthought = await _unitOfWork.EvidenceForHotThoughtRepository.GetItemAsync(evidenceForHotThoughtId);
            if (evidenceforhotthought == null) return BadRequest("Evidence For Hot Thought with specified Id does not exist");

            return Ok(_mapper.Map<EvidenceForHotThoughtDto>(evidenceforhotthought));
        }
    }
}
