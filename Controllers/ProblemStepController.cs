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
    public class ProblemStepController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProblemStepController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeproblemstep/{Id}")]
        public async Task<ActionResult<ProblemStepDto>> RemoveProblemStep(int Id)
        {
            var problemstep = await _unitOfWork.ProblemStepRepository.GetItemAsync(Id);
            if (problemstep == null) return NotFound("Could not find requested Problem Step");


            _unitOfWork.ProblemStepRepository.RemoveItem(problemstep);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ProblemStepDto>(problemstep));

            return BadRequest("Unable to remove Problem Step");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createproblemstep/{problemId}")]
        public async Task<ActionResult<ProblemStepDto>> CreateProblemStep(int problemId, CreateProblemStepDto createProblemStepDto)
        {
            var problemstep = new ProblemStep
            {
                Ideas = new Collection<ProblemIdea>(),
                PriorityOrder = createProblemStepDto.PriorityOrder,
                Problem = _mapper.Map<Problem>(await _unitOfWork.ProblemRepository.GetItemAsync(problemId)),
                Step = createProblemStepDto.Step
            };

            _unitOfWork.ProblemStepRepository.AddItem(problemstep);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ProblemStepDto>(problemstep));

            return BadRequest("Unable to create ProblemStep");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getproblemsteps/{problemId}")]
        public async Task<ActionResult<IEnumerable<ProblemStepDto>>> GetProblemStepsForProblem(int problemId)
        {
            var problemsteps = await _unitOfWork.ProblemStepRepository.GetItemsAsync(p => p.Problem.Id == problemId);
            if (problemsteps == null) return NotFound("There are no ProblemSteps stored");

            return Ok(problemsteps);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getproblemstep/{problemstepId}")]
        public async Task<ActionResult<ProblemStepDto>> GetProblemStepById(int problemstepId)
        {
            var problemstep = await _unitOfWork.ProblemStepRepository.GetItemAsync(problemstepId);
            if (problemstep == null) return BadRequest("ProblemStep with specified Id does not exist");

            return Ok(_mapper.Map<ProblemStepDto>(problemstep));
        }
    }
}
