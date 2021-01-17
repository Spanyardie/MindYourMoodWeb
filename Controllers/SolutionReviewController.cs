using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Controllers
{
    public class SolutionReviewController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SolutionReviewController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removesolutionreview/{Id}")]
        public async Task<ActionResult<SolutionReviewDto>> RemoveSolutionReview(int Id)
        {
            var solutionReview = await _unitOfWork.SolutionReviewRepository.GetItemAsync(Id);
            if (solutionReview == null) return NotFound("Could not find requested Solution Review");

            _unitOfWork.SolutionReviewRepository.RemoveItem(solutionReview);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<SolutionReviewDto>(solutionReview));

            return BadRequest("Unable to remove Solution Review");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createsolutionreview/{problemIdeaId}")]
        public async Task<ActionResult<SolutionReviewDto>> CreateSolutionReview(int problemIdeaId, CreateSolutionReviewDto createSolutionReviewDto)
        {
            var solutionReview = new SolutionReview
            {
                Achieved = createSolutionReviewDto.Achieved,
                AchievedDate = createSolutionReviewDto.AchievedDate,
                Idea = _mapper.Map<ProblemIdea>(await _unitOfWork.ProblemIdeaRepository.GetItemAsync(problemIdeaId)),
                ReviewText = createSolutionReviewDto.ReviewText,
                SolutionSteps = new Collection<SolutionPlan>()
            };

            _unitOfWork.SolutionReviewRepository.AddItem(solutionReview);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<SolutionReviewDto>(solutionReview));

            return BadRequest("Unable to create Solution Review");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getsolutionreviews/{problemIdeaId}")]
        public async Task<ActionResult<IEnumerable<SolutionReviewDto>>> GetSolutionReviewsForThoughtRecord(int problemIdeaId)
        {
            var solutionReviews = await _unitOfWork.SolutionReviewRepository.GetItemsAsync(pi => pi.Idea.Id == problemIdeaId);
            if (solutionReviews == null) return NotFound("There are no Solution Reviews stored");

            return Ok(solutionReviews);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getsolutionreview/{solutionReviewId}")]
        public async Task<ActionResult<SolutionReviewDto>> GetSolutionReviewById(int solutionReviewId)
        {
            var solutionReview = await _unitOfWork.SolutionReviewRepository.GetItemAsync(solutionReviewId);
            if (solutionReview == null) return BadRequest("Solution Review with specified Id does not exist");

            return Ok(_mapper.Map<SolutionReviewDto>(solutionReview));
        }
    }
}
