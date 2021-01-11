using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Controllers
{
    public class ThoughtRecordController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ThoughtRecordController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removethoughtrecord/{Id}")]
        public async Task<ActionResult<ThoughtRecordDto>> RemoveThoughtRecord(int Id)
        {
            var thoughtRecord = await _unitOfWork.ThoughtRecordRepository.GetItemAsync(Id);
            if (thoughtRecord == null) return NotFound("Could not find requested Thought Record");

            _unitOfWork.ThoughtRecordRepository.RemoveItem(thoughtRecord);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ThoughtRecordDto>(thoughtRecord));

            return BadRequest("Unable to remove Thought Record");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createthoughtrecord/{userId}")]
        public async Task<ActionResult<ThoughtRecordDto>> CreateThoughtRecord(int userId, CreateThoughtRecordDto createThoughtRecordDto)
        {
            var thoughtRecord = new ThoughtRecord
            {
                AlternativeThoughts = new Collection<AlternativeThought>(),
                AutomaticThoughts = new Collection<AutomaticThought>(),
                EvidenceAgainst = new Collection<EvidenceAgainstHotThought>(),
                EvidenceFor = new Collection<EvidenceForHotThought>(),
                Moods = new Collection<Mood>(),
                RecordDate = createThoughtRecordDto.RecordDate,
                ReRateMoods = new Collection<ReRateMood>(),
                Situation = new Collection<Situation>(),
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.ThoughtRecordRepository.AddItem(thoughtRecord);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ThoughtRecordDto>(thoughtRecord));

            return BadRequest("Unable to create Thought Record");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getthoughtrecords/{userId}")]
        public async Task<ActionResult<IEnumerable<ThoughtRecordDto>>> GetThoughtRecordsForUser(int userId)
        {
            var thoughtRecords = await _unitOfWork.ThoughtRecordRepository.GetItemsAsync(u => u.User.Id == userId);
            if (thoughtRecords == null) return NotFound("There are no Thought Records stored");

            return Ok(thoughtRecords);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getthoughtrecord/{userId}")]
        public async Task<ActionResult<ThoughtRecordDto>> GetThoughtRecordById(int userId)
        {
            var thoughtRecord = await _unitOfWork.ThoughtRecordRepository.GetItemAsync(userId);
            if (thoughtRecord == null) return BadRequest("Thought Record with specified Id does not exist");

            return Ok(_mapper.Map<ThoughtRecordDto>(thoughtRecord));
        }
    }
}
