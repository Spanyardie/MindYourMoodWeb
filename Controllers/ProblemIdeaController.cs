using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using MindYourMoodWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.ObjectModel;
using MindYourMoodWeb.Helpers;

namespace MindYourMoodWeb.Controllers
{
    public class ProblemIdeaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProblemIdeaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeproblemidea/{Id}")]
        public async Task<ActionResult<ProblemDto>> RemoveProblemIdea(int Id)
        {
            var problemIdea = await _unitOfWork.ProblemIdeaRepository.GetItemAsync(Id);
            if (problemIdea == null) return NotFound("Could not find requested Problem Idea");

            _unitOfWork.ProblemIdeaRepository.RemoveItem(problemIdea);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ProblemIdeaDto>(problemIdea));

            return BadRequest("Unable to remove Problem Idea");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createproblemidea")]
        public async Task<ActionResult<ProblemIdeaDto>> CreateProblemIdea(CreateProblemIdeaDto createProblemIdeaDto, [FromQuery] IdeaParams ideaParams)
        {
            var problemIdea = new ProblemIdea
            {
                Problem = await _unitOfWork.ProblemRepository.GetItemAsync(ideaParams.ProblemId),
                IdeaText = createProblemIdeaDto.IdeaText,
                ProsAndCons = new Collection<ProblemProCon>(),
                Step = await _unitOfWork.ProblemStepRepository.GetItemAsync(ideaParams.StepId)
            };

            _unitOfWork.ProblemIdeaRepository.AddItem(problemIdea);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ProblemIdeaDto>(problemIdea));

            return BadRequest("Unable to create Problem Idea");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getproblemideas/{problemStepId}")]
        public async Task<ActionResult<IEnumerable<ProblemDto>>> GetProblemsForStep(int problemStepId)
        {
            var problemIdeas = await _unitOfWork.ProblemIdeaRepository.GetItemsAsync(s => s.Step.Id == problemStepId);
            if (problemIdeas == null) return NotFound("There are no Problem Ideas stored");

            return Ok(problemIdeas);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getproblemidea/{problemIdeaId}")]
        public async Task<ActionResult<ProblemDto>> GetProblemById(int problemIdeaId)
        {
            var problemIdea = await _unitOfWork.ProblemIdeaRepository.GetItemAsync(problemIdeaId);
            if (problemIdea == null) return BadRequest("Problem Idea with specified Id does not exist");

            return Ok(_mapper.Map<ProblemIdeaDto>(problemIdea));
        }
    }
}
