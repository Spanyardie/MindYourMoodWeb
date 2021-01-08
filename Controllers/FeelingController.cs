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
    public class FeelingController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeelingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removefeeling/{Id}")]
        public async Task<ActionResult<FeelingDto>> RemoveFeeling(int Id)
        {
            var feeling = await _unitOfWork.FeelingRepository.GetFeelingAsync(Id);
            if (feeling == null) return NotFound("Could not find requested Feeling");


            _unitOfWork.FeelingRepository.RemoveFeeling(feeling);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<FeelingDto>(feeling));

            return BadRequest("Unable to remove Feeling");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createfeeling/{userId}")]
        public async Task<ActionResult<FeelingDto>> CreateFeeling(int userId, CreateFeelingDto createFeelingDto)
        {
            var feeling = new Feeling
            {
                ActionOf = createFeelingDto.ActionOf,
                DoAction = (IPlanAction.ActionType)createFeelingDto.DoAction,
                Strength = createFeelingDto.Strength,
                ToWhat = createFeelingDto.ToWhat,
                Type = (IPlanAction.ReactionType)createFeelingDto.Type,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.FeelingRepository.AddFeeling(feeling);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<FeelingDto>(feeling));

            return BadRequest("Unable to create Feeling");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getfeelings/{userId}")]
        public async Task<ActionResult<IEnumerable<FeelingDto>>> GetFeelingsForUser(int userId)
        {
            var feelings = await _unitOfWork.FeelingRepository.GetFeelingsAsync(userId);
            if (feelings == null) return NotFound("There are no Feelings stored");

            return Ok(feelings);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getfeeling/{feelingId}")]
        public async Task<ActionResult<FeelingDto>> GetFeelingById(int feelingId)
        {
            var feeling = await _unitOfWork.FeelingRepository.GetFeelingAsync(feelingId);
            if (feeling == null) return BadRequest("Feeling with specified Id does not exist");

            return Ok(_mapper.Map<FeelingDto>(feeling));
        }
    }
}
