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
    public class AlternativeThoughtController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AlternativeThoughtController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removealternativethought/{Id}")]
        public async Task<ActionResult<AlternativeThoughtDto>> RemoveAlternativeThought(int Id)
        {
            var alternativeThought = await _unitOfWork.AlternativeThoughtRepository.GetItemAsync(Id);
            if (alternativeThought == null) return NotFound("Could not find requested Alternative Thought");

            _unitOfWork.AlternativeThoughtRepository.RemoveItem(alternativeThought);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<AlternativeThoughtDto>(alternativeThought));

            return BadRequest("Unable to remove Alternative Thought");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createalternativethought/{thoughtRecordId}")]
        public async Task<ActionResult<AlternativeThoughtDto>> CreateAlternativeThought(int thoughtRecordId, CreateAlternativeThoughtDto createAlternativeThoughtDto)
        {
            var alternativeThought = new AlternativeThought
            {
                Alternative = createAlternativeThoughtDto.Alternative,
                BeliefRating = createAlternativeThoughtDto.BeliefRating,
                ThoughtRecord = await _unitOfWork.ThoughtRecordRepository.GetItemAsync(thoughtRecordId)
            };

            _unitOfWork.AlternativeThoughtRepository.AddItem(alternativeThought);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<AlternativeThoughtDto>(alternativeThought));

            return BadRequest("Unable to create Alternative Thought");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getalternativethoughts/{thoughtRecordId}")]
        public async Task<ActionResult<IEnumerable<AlternativeThoughtDto>>> GetAlternativeThoughtsForThoughtRecord(int thoughtRecordId)
        {
            var alternativeThoughts = await _unitOfWork.AlternativeThoughtRepository.GetItemsAsync(tr => tr.ThoughtRecord.Id == thoughtRecordId);
            if (alternativeThoughts == null) return NotFound("There are no Alternative Thoughts stored");

            return Ok(alternativeThoughts);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getalternativethought/{alternativeThoughtId}")]
        public async Task<ActionResult<AlternativeThoughtDto>> GetAlternativeThoughtById(int alternativeThoughtId)
        {
            var alternativeThought = await _unitOfWork.AlternativeThoughtRepository.GetItemAsync(alternativeThoughtId);
            if (alternativeThought == null) return BadRequest("Alternative Thought with specified Id does not exist");

            return Ok(_mapper.Map<AlternativeThoughtDto>(alternativeThought));
        }
    }
}
