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
    public class ProblemProConController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProblemProConController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeprocon/{Id}")]
        public async Task<ActionResult<ProblemProConDto>> RemoveHealth(int Id)
        {
            var problemProCon = await _unitOfWork.ProblemProConRepository.GetItemAsync(Id);
            if (problemProCon == null) return NotFound("Could not find requested Problem Pro Con");

            _unitOfWork.ProblemProConRepository.RemoveItem(problemProCon);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ProblemProConDto>(problemProCon));

            return BadRequest("Unable to remove Problem Pro Con");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createprocon")]
        public async Task<ActionResult<ProblemProConDto>> CreateHealth(CreateProblemProConDto createProblemProConDto)
        {
            var problemProCon = new ProblemProCon
            {
                Idea = await _unitOfWork.ProblemIdeaRepository.GetItemAsync(createProblemProConDto.IdeaId),
                Problem = await _unitOfWork.ProblemRepository.GetItemAsync(createProblemProConDto.ProblemId),
                ProConText = createProblemProConDto.ProConText,
                Step = await _unitOfWork.ProblemStepRepository.GetItemAsync(createProblemProConDto.StepId),
                Type = (ProblemProCon.ProblemType)createProblemProConDto.Type
            };

            _unitOfWork.ProblemProConRepository.AddItem(problemProCon);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ProblemProConDto>(problemProCon));

            return BadRequest("Unable to create ProblemProCon");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getprocons/{ideaId}")]
        public async Task<ActionResult<IEnumerable<ProblemProConDto>>> GetProConsForIdea(int ideaId)
        {
            var procons = await _unitOfWork.ProblemProConRepository.GetItemsAsync(i => i.Idea.Id == ideaId);
            if (procons == null) return NotFound("There are no Problem Pro Cons stored");

            return Ok(procons);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getprocon/{proconId}")]
        public async Task<ActionResult<ProblemProConDto>> GetHealthById(int proconId)
        {
            var problemProCon = await _unitOfWork.ProblemProConRepository.GetItemAsync(proconId);
            if (problemProCon == null) return BadRequest("Problem Pro Con with specified Id does not exist");

            return Ok(_mapper.Map<ProblemProConDto>(problemProCon));
        }
    }
}
