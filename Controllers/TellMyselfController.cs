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
    public class TellMyselfController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TellMyselfController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removetellmyself/{Id}")]
        public async Task<ActionResult<TellMyselfDto>> RemoveTellMyself(int Id)
        {
            var tellMyself = await _unitOfWork.TellMyselfRepository.GetItemAsync(Id);
            if (tellMyself == null) return NotFound("Could not find requested Tell Myself");

            _unitOfWork.TellMyselfRepository.RemoveItem(tellMyself);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<TellMyselfDto>(tellMyself));

            return BadRequest("Unable to remove Tell Myself");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createtellmyself/{userId}")]
        public async Task<ActionResult<TellMyselfDto>> CreateTellMyself(int userId, CreateTellMyselfDto createTellMyselfDto)
        {
            var tellMyself = new TellMyself
            {
                TellText = createTellMyselfDto.TellText,
                TellTitle = createTellMyselfDto.TellTitle,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.TellMyselfRepository.AddItem(tellMyself);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<TellMyselfDto>(tellMyself));

            return BadRequest("Unable to create Tell Myself");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("gettellmyselfs/{userId}")]
        public async Task<ActionResult<IEnumerable<TellMyselfDto>>> GetTellMyselfsForThoughtRecord(int userId)
        {
            var tellMyselfs = await _unitOfWork.TellMyselfRepository.GetItemsAsync(u => u.User.Id == userId);
            if (tellMyselfs == null) return NotFound("There are no Tell Myselfs stored");

            return Ok(tellMyselfs);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("gettellmyself/{tellMyselfId}")]
        public async Task<ActionResult<TellMyselfDto>> GetTellMyselfById(int tellMyselfId)
        {
            var tellMyself = await _unitOfWork.TellMyselfRepository.GetItemAsync(tellMyselfId);
            if (tellMyself == null) return BadRequest("Tell Myself with specified Id does not exist");

            return Ok(_mapper.Map<TellMyselfDto>(tellMyself));
        }
    }
}
