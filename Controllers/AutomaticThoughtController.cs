using MindYourMoodWeb.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.ObjectModel;

namespace MindYourMoodWeb.Controllers
{
    public class AutomaticThoughtController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AutomaticThoughtController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeautomaticthought/{Id}")]
        public async Task<ActionResult<AutomaticThoughtDto>> RemoveAutomaticThought(int Id)
        {
            var automaticThought = await _unitOfWork.AutomaticThoughtRepository.GetAutomaticThoughtAsync(Id);
            if (automaticThought == null) return NotFound("Could not find requested Automatic Thought");


            _unitOfWork.AutomaticThoughtRepository.RemoveAutomaticThought(automaticThought);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<AutomaticThoughtDto>(automaticThought));

            return BadRequest("Unable to remove Automatic Thought");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createautomaticthought/{thoughtRecordId}")]
        public async Task<ActionResult<AutomaticThoughtDto>> CreateAutomaticThought(int thoughtRecordId, CreateAutomaticThoughtDto createAutomaticThoughtDto)
        {
            var automaticThought = new AutomaticThought
            {
                EvidenceAgainstHotThought = await _unitOfWork.EvidenceAgainstHotThoughtRepository.GetEvidencesAgainstHotThought(createAutomaticThoughtDto.ThoughtRecordid),
                EvidenceForHotThought = await _unitOfWork.EvidencesForHotThought(createAutomaticThoughtDto.ThoughtRecordid),
                HotThought = createAutomaticThoughtDto.HotThought,
                Thought = createAutomaticThoughtDto.Thought,
                ThoughtRecord = _unitOfWork.ThoughtRecordRepository.GetThoughtRecord(thoughtRecordId)
            };

            _unitOfWork.AutomaticThoughtRepository.AddAutomaticThought(automaticThought);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<AutomaticThoughtDto>(automaticThought));

            return BadRequest("Unable to create Automatic Thought");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getautomaticthoughts/{thoughtRecordId}")]
        public async Task<ActionResult<IEnumerable<AutomaticThoughtDto>>> GetMoodsForThoughtRecord(int thoughtRecordId)
        {
            var automaticThoughts = await _unitOfWork.AutomaticThoughtRepository.GetAutomaticThoughtsAsync(thoughtRecordId);
            if (automaticThoughts == null) return NotFound("There are no Automatic Thoughts stored");

            return Ok(automaticThoughts);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getautomaticthought/{automaticThoughtId}")]
        public async Task<ActionResult<AutomaticThoughtDto>> GetAutomaticThoughtById(int automaticThoughtId)
        {
            var automaticThought = await _unitOfWork.AutomaticThoughtRepository.GetAutomaticThoughtAsync(automaticThoughtId);
            if (automaticThought == null) return BadRequest("Automatic Thought with specified Id does not exist");

            return Ok(_mapper.Map<AutomaticThoughtDto>(automaticThought));
        }
    }
}
