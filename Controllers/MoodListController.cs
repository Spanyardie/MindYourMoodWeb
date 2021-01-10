using MindYourMoodWeb.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;

namespace MindYourMoodWeb.Controllers
{
    public class MoodListController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MoodListController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removemoodlist/{Id}")]
        public async Task<ActionResult<MoodListDto>> RemoveMoodList(int Id)
        {
            var moodlist = await _unitOfWork.MoodListRepository.GetItemAsync(Id);
            if (moodlist == null) return NotFound("Could not find requested MoodList");


            _unitOfWork.MoodListRepository.RemoveItem(moodlist);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<MoodListDto>(moodlist));

            return BadRequest("Unable to remove MoodList");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createmoodlist/{moodId}")]
        public async Task<ActionResult<MoodListDto>> CreateMoodList(int moodId, CreateMoodListDto createMoodListDto)
        {
            var moodlist = new MoodList
            {
                IsDefault = createMoodListDto.IsDefault,
                IsoCountry = createMoodListDto.IsoCountry,
                MoodName = createMoodListDto.MoodName
            };

            _unitOfWork.MoodListRepository.AddItem(moodlist);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<MoodListDto>(moodlist));

            return BadRequest("Unable to create MoodList");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getmoodlists")]
        public async Task<ActionResult<IEnumerable<MoodListDto>>> GetMoodLists()
        {
            var moodlists = await _unitOfWork.MoodListRepository.GetItemsAsync(null);
            if (moodlists == null) return NotFound("There are no MoodLists stored");

            return Ok(moodlists);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getmoodlist/{moodlistId}")]
        public async Task<ActionResult<MoodListDto>> GetMoodListById(int moodlistId)
        {
            var moodlist = await _unitOfWork.MoodListRepository.GetItemAsync(moodlistId);
            if (moodlist == null) return BadRequest("MoodList with specified Id does not exist");

            return Ok(_mapper.Map<MoodListDto>(moodlist));
        }
    }
}
