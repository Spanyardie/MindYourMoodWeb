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
            var automaticThought = await _unitOfWork.AutomaticThoughtRepository.GetItemAsync(Id);
            if (automaticThought == null) return NotFound("Could not find requested Automatic Thought");

            _unitOfWork.AutomaticThoughtRepository.RemoveItem(automaticThought);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<AutomaticThoughtDto>(automaticThought));

            return BadRequest("Unable to remove Automatic Thought");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createautomaticthought/{thoughtRecordId}")]
        public async Task<ActionResult<AutomaticThoughtDto>> CreateAutomaticThought(int thoughtRecordId, CreateAutomaticThoughtDto createAutomaticThoughtDto)
        {
            var automaticThought = new AutomaticThought
            {
                EvidenceAgainstHotThought = (IEnumerable<EvidenceAgainstHotThought>)await _unitOfWork.EvidenceAgainstHotThoughtRepository.GetItemsAsync(tr => tr.ThoughtRecord.Id ==createAutomaticThoughtDto.ThoughtRecordid),
                EvidenceForHotThought = (IEnumerable<EvidenceForHotThought>)await _unitOfWork.EvidenceForHotThoughtRepository.GetItemsAsync(tr => tr.ThoughtRecord.Id == createAutomaticThoughtDto.ThoughtRecordid),
                HotThought = createAutomaticThoughtDto.HotThought,
                Thought = createAutomaticThoughtDto.Thought,
                ThoughtRecord = _mapper.Map<ThoughtRecord>(await _unitOfWork.ThoughtRecordRepository.GetItemAsync(thoughtRecordId))
            };

            _unitOfWork.AutomaticThoughtRepository.AddItem(automaticThought);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<AutomaticThoughtDto>(automaticThought));

            return BadRequest("Unable to create Automatic Thought");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getautomaticthoughts/{thoughtRecordId}")]
        public async Task<ActionResult<IEnumerable<AutomaticThoughtDto>>> GetAutomaticThoughtsForThoughtRecord(int thoughtRecordId)
        {
            var automaticThoughts = await _unitOfWork.AutomaticThoughtRepository.GetItemsAsync(tr => tr.ThoughtRecord.Id == thoughtRecordId);
            if (automaticThoughts == null) return NotFound("There are no Automatic Thoughts stored");

            return Ok(automaticThoughts);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getautomaticthought/{automaticThoughtId}")]
        public async Task<ActionResult<AutomaticThoughtDto>> GetAutomaticThoughtById(int automaticThoughtId)
        {
            var automaticThought = await _unitOfWork.AutomaticThoughtRepository.GetItemAsync(automaticThoughtId);
            if (automaticThought == null) return BadRequest("Automatic Thought with specified Id does not exist");

            return Ok(_mapper.Map<AutomaticThoughtDto>(automaticThought));
        }
    }
}
