using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Controllers
{
    public class ChuffChartController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChuffChartController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removechuffchartitem/{id}")]
        public async Task<ActionResult> RemoveChuffChartItem(int Id)
        {
            var chuffChartitem = await _unitOfWork.ChuffChartRepository.GetItemAsync(Id);
            if (chuffChartitem == null) return NotFound("Could not find requested Chuff chart item");


            _unitOfWork.ChuffChartRepository.RemoveItem(_mapper.Map<ChuffChartItem>(chuffChartitem));

            if(await _unitOfWork.Complete()) return Ok(_mapper.Map<ChuffChartItemDto>(chuffChartitem));

            return BadRequest("Unable to remove Chuff Chart item");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createchuffchartitem/{userId}")]
        public async Task<ActionResult<ChuffChartItemDto>> CreateChuffChartItem(int userId, CreateChuffChartItemDto createChuffChartItemDto)
        {
            var chuffChartItem = new ChuffChartItem
            {
                Achievement = createChuffChartItemDto.Achievement,
                AchievementDate = DateTime.Now,
                ChuffChartType = (ChuffChartItem.AchievementType)createChuffChartItemDto.ChuffChartType,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.ChuffChartRepository.AddItem(chuffChartItem);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ChuffChartItemDto>(chuffChartItem));

            return BadRequest("Unable to create Chuff chart item");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getchuffchartitems/{userId}")]
        public async Task<ActionResult<IEnumerable<ChuffChartItemDto>>> GetChuffChartItemsForUser(int userId)
        {
            var chuffChartItems = await _unitOfWork.ChuffChartRepository.GetItemsAsync(u => u.User.Id == userId);
            if (chuffChartItems == null) return NotFound("There are no Chuff chart items stored");

            return Ok(chuffChartItems);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getchuffchartitem/{itemId}")]
        public async Task<ActionResult<ChuffChartItemDto>> GetChuffChartItemById(int itemId)
        {
            var chuffChartitem = await _unitOfWork.ChuffChartRepository.GetItemAsync(itemId);
            if (chuffChartitem == null) return BadRequest("Chuff chart item with specified Id does not exist");

            return Ok(_mapper.Map<ChuffChartItemDto>(chuffChartitem));
        }
    }
}
