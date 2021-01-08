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
    public class GenericTextController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenericTextController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removegenerictext/{Id}")]
        public async Task<ActionResult<GenericTextDto>> RemoveGenericText(int Id)
        {
            var genericText = await _unitOfWork.GenericTextRepository.GetGenericTextAsync(Id);
            if (genericText == null) return NotFound("Could not find requested Generic Text");

            _unitOfWork.GenericTextRepository.RemoveGenericText(genericText);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<GenericTextDto>(genericText));

            return BadRequest("Unable to remove Generic Text");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("creategenerictext/{userId}")]
        public async Task<ActionResult<GenericTextDto>> CreateGenericText(int userId, CreateGenericTextDto createGenericTextDto)
        {
            var genericText = new GenericText
            {
                TextType = createGenericTextDto.TextType,
                TextValue = createGenericTextDto.TextValue,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.GenericTextRepository.AddGenericText(genericText);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<GenericTextDto>(genericText));

            return BadRequest("Unable to create Generic Text");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getgenerictexts/{userId}")]
        public async Task<ActionResult<IEnumerable<GenericTextDto>>> GetGenericTextsForUser(int userId)
        {
            var genericTexts = await _unitOfWork.GenericTextRepository.GetGenericTextsAsync(userId);
            if (genericTexts == null) return NotFound("There are no Generic Text items stored");

            return Ok(genericTexts);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getgenerictext/{genericTextId}")]
        public async Task<ActionResult<GenericTextDto>> GetGenericTextById(int genericTextId)
        {
            var genericText = await _unitOfWork.GenericTextRepository.GetGenericTextAsync(genericTextId);
            if (genericText == null) return BadRequest("Generic Text with specified Id does not exist");

            return Ok(_mapper.Map<GenericTextDto>(genericText));
        }

    }
}
