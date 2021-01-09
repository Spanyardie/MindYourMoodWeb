using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using MindYourMoodWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.ObjectModel;

namespace MindYourMoodWeb.Controllers
{
    public class ProblemController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProblemController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeproblem/{Id}")]
        public async Task<ActionResult<ProblemDto>> RemoveProblem(int Id)
        {
            var problem = await _unitOfWork.ProblemRepository.GetProblemAsync(Id);
            if (problem == null) return NotFound("Could not find requested Problem");

            _unitOfWork.ProblemRepository.RemoveProblem(problem);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ProblemDto>(problem));

            return BadRequest("Unable to remove Problem");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createproblem/{userId}")]
        public async Task<ActionResult<ProblemDto>> CreateProblem(int userId, CreateProblemDto createProblemDto)
        {
            var problem = new Problem
            {
                ProblemText = createProblemDto.ProblemText,
                Steps = new Collection<ProblemStep>(),
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.ProblemRepository.AddProblem(problem);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ProblemDto>(problem));

            return BadRequest("Unable to create Problem");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getproblems/{userId}")]
        public async Task<ActionResult<IEnumerable<ProblemDto>>> GetProblemsForUser(int userId)
        {
            var problems = await _unitOfWork.ProblemRepository.GetProblemsAsync(userId);
            if (problems == null) return NotFound("There are no Problems stored");

            return Ok(problems);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getproblem/{problemId}")]
        public async Task<ActionResult<ProblemDto>> GetProblemById(int problemId)
        {
            var problem = await _unitOfWork.ProblemRepository.GetProblemAsync(problemId);
            if (problem == null) return BadRequest("Problem with specified Id does not exist");

            return Ok(_mapper.Map<ProblemDto>(problem));
        }
    }
}
