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
    public class ContactController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removecontact/{Id}")]
        public async Task<ActionResult<ContactDto>> RemoveContact(int Id)
        {
            var contact = await _unitOfWork.ContactRepository.GetContactAsync(Id);
            if (contact == null) return NotFound("Could not find requested Contact");

            _unitOfWork.ContactRepository.RemoveContact(contact);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ContactDto>(contact));

            return BadRequest("Unable to remove Contact");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createcontact/{userId}")]
        public async Task<ActionResult<ContactDto>> CreateContact(int userId, CreateContactDto createContactDto)
        {
            var contact = new Contact
            {
                Email = createContactDto.Email,
                Name = createContactDto.Name,
                PhotoId = createContactDto.PhotoId,
                TelephoneNumber = createContactDto.TelephoneNumber,
                Uri = createContactDto.Uri,
                UseEmergencyCall = createContactDto.UseEmergencyCall,
                UseEmergencyEmail = createContactDto.UseEmergencyEmail,
                UseEmergencySms = createContactDto.UseEmergencySms,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.ContactRepository.AddContact(contact);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<ContactDto>(contact));

            return BadRequest("Unable to create Contact");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getcontacts/{userId}")]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetContactsForUser(int userId)
        {
            var contacts = await _unitOfWork.ContactRepository.GetContactsAsync(userId);
            if (contacts == null) return NotFound("There are no Contacts stored");

            return Ok(contacts);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getcontact/{contactId}")]
        public async Task<ActionResult<ContactDto>> GetContactById(int contactId)
        {
            var contact = await _unitOfWork.ContactRepository.GetContactAsync(contactId);
            if (contact == null) return BadRequest("Contact with specified Id does not exist");

            return Ok(_mapper.Map<ContactDto>(contact));
        }
    }
}
