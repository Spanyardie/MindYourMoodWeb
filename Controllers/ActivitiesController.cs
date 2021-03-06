﻿using AutoMapper;
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
    public class ActivitiesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActivitiesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Member")]
        [HttpDelete("removeactivity/{Id}")]
        public async Task<ActionResult<ActivityDto>> RemoveActivity(int Id)
        {
            var activity = await _unitOfWork.ActivitiesRepository.GetItemAsync(Id);
            if (activity == null) return NotFound("Could not find requested Activity");

            _unitOfWork.ActivitiesRepository.RemoveItem(_mapper.Map<Activities>(activity));

            if (await _unitOfWork.Complete()) return Ok(activity);

            return BadRequest("Unable to remove Activity");
        }

        //[Authorize(Roles = "Member")]
        [HttpPost("createactivity")]
        public async Task<ActionResult<ActivityDto>> CreateActivity(CreateActivitiesDto createActivityDto)
        {
            var activity = new Activities
            {
                ActivityDate = createActivityDto.ActivityDate,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(createActivityDto.UserId),
                ActivityTimes = new Collection<ActivityTimes>()
            };

            _unitOfWork.ActivitiesRepository.AddItem(activity);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ActivityDto>(activity));

            return BadRequest("Unable to create Activity");
        }

        //[Authorize(Roles = "Member")]
        [HttpGet("getactivities/{userId}")]
        public async Task<ActionResult<IEnumerable<ActivityDto>>> GetActivitiesForUser(int userId)
        {
            var activities = await _unitOfWork.ActivitiesRepository.GetItemsAsync(u => u.UserId == userId);
            if (activities == null) return NotFound("There are no Activities stored");

            return Ok(_mapper.Map<IEnumerable<ActivityDto>>(activities));
        }

        //[Authorize(Roles = "Member")]
        [HttpGet("getactivity/{activityId}")]
        public async Task<ActionResult<ActivityDto>> GetActivityById(int activityId)
        {
            var activity = await _unitOfWork.ActivitiesRepository.GetItemAsync(activityId);
            if (activity == null) return BadRequest("Activity with specified Id does not exist");

            return Ok(_mapper.Map<ActivityDto>(activity));
        }
    }
}
