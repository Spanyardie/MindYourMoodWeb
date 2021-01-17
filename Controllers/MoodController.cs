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
    public class MoodController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MoodController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removemood/{Id}")]
        public async Task<ActionResult<MoodDto>> RemoveMood(int Id)
        {
            var mood = await _unitOfWork.MoodRepository.GetItemAsync(Id);
            if (mood == null) return NotFound("Could not find requested Mood");


            _unitOfWork.MoodRepository.RemoveItem(mood);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<MoodDto>(mood));

            return BadRequest("Unable to remove Mood");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createmood/{thoughtRecordId}")]
        public async Task<ActionResult<MoodDto>> CreateMood(int thoughtRecordId, CreateMoodDto createMoodDto)
        {
            var mood = new Mood
            {
                MoodList = _mapper.Map<MoodList>(await _unitOfWork.MoodListRepository.GetItemAsync(createMoodDto.MoodListId)),
                ThoughtRecord = _mapper.Map<ThoughtRecord>(await _unitOfWork.ThoughtRecordRepository.GetItemAsync(thoughtRecordId)),
                MoodRating = createMoodDto.MoodRating
            };

            _unitOfWork.MoodRepository.AddItem(mood);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<MoodDto>(mood));

            return BadRequest("Unable to create Mood");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getmoods/{thoughtRecordId}")]
        public async Task<ActionResult<IEnumerable<MoodDto>>> GetMoodsForThoughtRecord(int thoughtRecordId)
        {
            var moods = await _unitOfWork.MoodRepository.GetItemsAsync(tr => tr.ThoughtRecord.Id == thoughtRecordId);
            if (moods == null) return NotFound("There are no Moods stored");

            return Ok(moods);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getmood/{moodId}")]
        public async Task<ActionResult<MoodDto>> GetMoodById(int moodId)
        {
            var mood = await _unitOfWork.MoodRepository.GetItemAsync(moodId);
            if (mood == null) return BadRequest("Mood with specified Id does not exist");

            return Ok(_mapper.Map<MoodDto>(mood));
        }
    }
}
