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
    public class RelationshipController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RelationshipController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removerelationship/{Id}")]
        public async Task<ActionResult<RelationshipDto>> RemoveRelationship(int Id)
        {
            var relationship = await _unitOfWork.RelationshipRepository.GetItemAsync(Id);
            if (relationship == null) return NotFound("Could not find requested Relationship");

            _unitOfWork.RelationshipRepository.RemoveItem(relationship);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<RelationshipDto>(relationship));

            return BadRequest("Unable to remove Relationship");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createrelationship/{userId}")]
        public async Task<ActionResult<RelationshipDto>> CreateRelationship(int userId, CreateRelationshipDto createRelationshipDto)
        {
            var relationship = new Relationship
            {
                ActionOf = createRelationshipDto.ActionOf,
                DoAction = (IPlanAction.ActionType)createRelationshipDto.DoAction,
                Feeling = (IFeeling.FeelingType)createRelationshipDto.Feeling,
                Strength = createRelationshipDto.Strength,
                ToWhat = createRelationshipDto.ToWhat,
                Type = (IPlanAction.ReactionType)createRelationshipDto.Type,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.RelationshipRepository.AddItem(relationship);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<RelationshipDto>(relationship));

            return BadRequest("Unable to create Relationship");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getrelationships/{userId}")]
        public async Task<ActionResult<IEnumerable<RelationshipDto>>> GetRelationshipsForUser(int userId)
        {
            var relationships = await _unitOfWork.RelationshipRepository.GetItemsAsync(u => u.User.Id == userId);
            if (relationships == null) return NotFound("There are no Relationships stored");

            return Ok(relationships);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getrelationship/{relationshipId}")]
        public async Task<ActionResult<RelationshipDto>> GetRelationshipById(int relationshipId)
        {
            var relationship = await _unitOfWork.RelationshipRepository.GetItemAsync(relationshipId);
            if (relationship == null) return BadRequest("Relationship with specified Id does not exist");

            return Ok(_mapper.Map<RelationshipDto>(relationship));
        }
    }
}
