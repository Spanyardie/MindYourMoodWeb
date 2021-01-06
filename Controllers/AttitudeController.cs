using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using MindYourMoodWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;

namespace MindYourMoodWeb.Controllers
{
    public class AttitudeController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AttitudeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeattitude/{Id}")]
        public async Task<ActionResult<AttitudeDto>> RemoveAttitude(int Id)
        {
            var attitude = await _unitOfWork.AttitudeRepository.GetAttitudeAsync(Id);
            if (attitude == null) return NotFound("Could not find requested Attitude");


            _unitOfWork.AttitudeRepository.RemoveAttitude(attitude);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<AttitudeDto>(attitude));

            return BadRequest("Unable to remove Attitude");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createattitude/{userId}")]
        public async Task<ActionResult<AttitudeDto>> CreateAttitude(int userId, CreateAttitudeDto createAttitudeDto)
        {
            var attitude = new Attitude
            {
                ActionOf = createAttitudeDto.ActionOf,
                DoAction = (IPlanAction.ActionType)createAttitudeDto.DoAction,
                Feeling = (IFeeling.FeelingType)createAttitudeDto.Feeling,
                Strength = createAttitudeDto.Strength,
                ToWhat = createAttitudeDto.ToWhat,
                Type = (IPlanAction.ReactionType)createAttitudeDto.Type,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.AttitudeRepository.AddAttitude(attitude);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<AttitudeDto>(attitude));

            return BadRequest("Unable to create Attitude");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getattitudes/{userId}")]
        public async Task<ActionResult<IEnumerable<AttitudeDto>>> GetAttitudesForUser(int userId)
        {
            var attitudes = await _unitOfWork.AttitudeRepository.GetAttitudesAsync(userId);
            if (attitudes == null) return NotFound("There are no Attitudes stored");

            return Ok(attitudes);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getattitude/{attitudeId}")]
        public async Task<ActionResult<AttitudeDto>> GetAttitudeById(int attitudeId)
        {
            var attitude = await _unitOfWork.AttitudeRepository.GetAttitudeAsync(attitudeId);
            if (attitude == null) return BadRequest("Attitude with specified Id does not exist");

            return Ok(_mapper.Map<AttitudeDto>(attitude));
        }
    }
}
