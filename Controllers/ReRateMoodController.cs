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
    public class ReRateMoodController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReRateMoodController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removereratemood/{Id}")]
        public async Task<ActionResult<ReRateMoodDto>> RemoveReRateMood(int Id)
        {
            var reratemood = await _unitOfWork.ReRateMoodRepository.GetItemAsync(Id);
            if (reratemood == null) return NotFound("Could not find requested ReRate Mood");

            _unitOfWork.ReRateMoodRepository.RemoveItem(reratemood);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ReRateMoodDto>(reratemood));

            return BadRequest("Unable to remove ReRate Mood");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createreratemood/{thoughtRecordId}")]
        public async Task<ActionResult<ReRateMoodDto>> CreateReRateMood(int thoughtRecordId, CreateReRateMoodDto createReRateMoodDto)
        {
            var reratemood = new ReRateMood
            {
                Mood = await _unitOfWork.MoodRepository.GetItemAsync(createReRateMoodDto.MoodsId),
                MoodListId = createReRateMoodDto.MoodListId,
                MoodRating = createReRateMoodDto.MoodRating,
                ThoughtRecord = await _unitOfWork.ThoughtRecordRepository.GetItemAsync(thoughtRecordId)
            };

            _unitOfWork.ReRateMoodRepository.AddItem(reratemood);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ReRateMoodDto>(reratemood));

            return BadRequest("Unable to create ReRate Mood");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getreratemoods/{thoughtRecordId}")]
        public async Task<ActionResult<IEnumerable<ReRateMoodDto>>> GetReRateMoodsForThoughtRecord(int thoughtRecordId)
        {
            var reratemoods = await _unitOfWork.ReRateMoodRepository.GetItemsAsync(tr => tr.ThoughtRecord.Id == thoughtRecordId);
            if (reratemoods == null) return NotFound("There are no ReRate Moods stored");

            return Ok(reratemoods);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getreratemood/{reratemoodId}")]
        public async Task<ActionResult<ReRateMoodDto>> GetReRateMoodById(int reratemoodId)
        {
            var reratemood = await _unitOfWork.ReRateMoodRepository.GetItemAsync(reratemoodId);
            if (reratemood == null) return BadRequest("ReRate Mood with specified Id does not exist");

            return Ok(_mapper.Map<ReRateMoodDto>(reratemood));
        }
    }
}
