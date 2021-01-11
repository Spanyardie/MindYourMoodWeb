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
    public class SolutionPlanController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SolutionPlanController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removesolutionplan/{Id}")]
        public async Task<ActionResult<SolutionPlanDto>> RemoveSolutionPlan(int Id)
        {
            var solutionPlan = await _unitOfWork.SolutionPlanRepository.GetItemAsync(Id);
            if (solutionPlan == null) return NotFound("Could not find requested Solution Plan");

            _unitOfWork.SolutionPlanRepository.RemoveItem(solutionPlan);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<SolutionPlanDto>(solutionPlan));

            return BadRequest("Unable to remove Solution Plan");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createsolutionplan/{solutionReviewId}")]
        public async Task<ActionResult<SolutionPlanDto>> CreateSolutionPlan(int solutionReviewId, CreateSolutionPlanDto createSolutionPlanDto)
        {
            var solutionPlan = new SolutionPlan
            {
                PriorityOrder = createSolutionPlanDto.PriorityOrder,
                SolutionReview = await _unitOfWork.SolutionReviewRepository.GetItemAsync(solutionReviewId),
                SolutionStep = createSolutionPlanDto.SolutionStep
            };

            _unitOfWork.SolutionPlanRepository.AddItem(solutionPlan);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<SolutionPlanDto>(solutionPlan));

            return BadRequest("Unable to create Solution Plan");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getsolutionplans/{solutionReviewId}")]
        public async Task<ActionResult<IEnumerable<SolutionPlanDto>>> GetSolutionPlansForThoughtRecord(int solutionReviewId)
        {
            var solutionPlans = await _unitOfWork.SolutionPlanRepository.GetItemsAsync(sr => sr.SolutionReview.Id == solutionReviewId);
            if (solutionPlans == null) return NotFound("There are no Solution Plans stored");

            return Ok(solutionPlans);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getsolutionplan/{solutionPlanId}")]
        public async Task<ActionResult<SolutionPlanDto>> GetSolutionPlanById(int solutionPlanId)
        {
            var solutionPlan = await _unitOfWork.SolutionPlanRepository.GetItemAsync(solutionPlanId);
            if (solutionPlan == null) return BadRequest("Solution Plan with specified Id does not exist");

            return Ok(_mapper.Map<SolutionPlanDto>(solutionPlan));
        }
    }
}
