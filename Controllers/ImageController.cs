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
    public class ImageController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ImageController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeimage/{Id}")]
        public async Task<ActionResult<ImageDto>> RemoveImage(int Id)
        {
            var image = await _unitOfWork.ImageRepository.GetItemAsync(Id);
            if (image == null) return NotFound("Could not find requested Image");

            _unitOfWork.ImageRepository.RemoveItem(image);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ImageDto>(image));

            return BadRequest("Unable to remove Image");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createimage/{userId}")]
        public async Task<ActionResult<ImageDto>> CreateImage(int userId, CreateImageDto createImageDto)
        {
            var image = new Image
            {
                Comment = createImageDto.Comment,
                Uri = createImageDto.Uri,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.ImageRepository.AddItem(image);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ImageDto>(image));

            return BadRequest("Unable to create Image");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getimages/{userId}")]
        public async Task<ActionResult<IEnumerable<ImageDto>>> GetImagesForThoughtRecord(int userId)
        {
            var images = await _unitOfWork.ImageRepository.GetItemsAsync(u => u.User.Id == userId);
            if (images == null) return NotFound("There are no Images stored");

            return Ok(images);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getimage/{imageId}")]
        public async Task<ActionResult<ImageDto>> GetImageById(int imageId)
        {
            var image = await _unitOfWork.ImageRepository.GetItemAsync(imageId);
            if (image == null) return BadRequest("Image with specified Id does not exist");

            return Ok(_mapper.Map<ImageDto>(image));
        }
    }
}
