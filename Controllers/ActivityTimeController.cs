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
    public class ActivityTimeController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActivityTimeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeactivitytime/{Id}")]
        public async Task<ActionResult<ActivityTimeDto>> RemoveActivityTime(int Id)
        {
            var activitytime = await _unitOfWork.ActivityTimesRepository.GetActivityTimeAsync(Id);
            if (activitytime == null) return NotFound("Could not find requested Activity time");

            _unitOfWork.ActivityTimesRepository.RemoveActivityTime(activitytime);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ActivityTimeDto>(activitytime));

            return BadRequest("Unable to remove Activity time");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createactivitytime/{activityId}")]
        public async Task<ActionResult<ActivityTimeDto>> CreateActivity(int activityId, CreateActivityTimeDto createActivityTimeDto)
        {
            var activitytime = new ActivityTimes
            {
                Achievement = createActivityTimeDto.Achievement,
                Activity = await _unitOfWork.ActivitiesRepository.GetActivityAsync(activityId),
                ActivityName = createActivityTimeDto.ActivityName,
                Intimacy = createActivityTimeDto.Intimacy,
                Pleasure = createActivityTimeDto.Pleasure,
                Time = createActivityTimeDto.Time
            };

            _unitOfWork.ActivityTimesRepository.AddActivityTime(activitytime);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ActivityTimeDto>(activitytime));

            return BadRequest("Unable to create Activity time");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getactivitytimes/{userId}")]
        public async Task<ActionResult<IEnumerable<ActivityTimeDto>>> GetActivityTimesForActivity(int activityId)
        {
            var activities = await _unitOfWork.ActivityTimesRepository.GetActivityTimesAsync(activityId);
            if (activities == null) return NotFound("There are no Activity times stored");

            return Ok(activities);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getactivitytime/{activitytimeId}")]
        public async Task<ActionResult<ActivityTimeDto>> GetActivityById(int activitytimeId)
        {
            var activitytime = await _unitOfWork.ActivityTimesRepository.GetActivityTimeAsync(activitytimeId);
            if (activitytime == null) return BadRequest("Activity time with specified Id does not exist");

            return Ok(_mapper.Map<ActivityTimeDto>(activitytime));
        }
    }
}
