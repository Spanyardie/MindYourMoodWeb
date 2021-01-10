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
    public class PrescriptionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrescriptionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeprescription/{Id}")]
        public async Task<ActionResult<PrescriptionDto>> RemovePrescription(int Id)
        {
            var prescription = await _unitOfWork.PrescriptionRepository.GetItemAsync(Id);
            if (prescription == null) return NotFound("Could not find requested Prescription");

            _unitOfWork.PrescriptionRepository.RemoveItem(prescription);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<PrescriptionDto>(prescription));

            return BadRequest("Unable to remove Prescription");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createprescription/{userId}")]
        public async Task<ActionResult<PrescriptionDto>> CreatePrescription(int userId, CreatePrescriptionDto createPrescriptionDto)
        {
            var prescription = new Prescription
            {
                MonthlyDay = createPrescriptionDto.MonthlyDay,
                WeeklyDay = createPrescriptionDto.WeeklyDay,
                PrescriptionType = createPrescriptionDto.PrescriptionType,
                Medications = new Collection<Medication>(),
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.PrescriptionRepository.AddItem(prescription);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<PrescriptionDto>(prescription));

            return BadRequest("Unable to create Prescription");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getprescriptions/{userId}")]
        public async Task<ActionResult<IEnumerable<PrescriptionDto>>> GetPrescriptionsForUser(int userId)
        {
            var prescriptions = await _unitOfWork.PrescriptionRepository.GetItemsAsync(u => u.User.Id == userId);
            if (prescriptions == null) return NotFound("There are no Prescriptions stored");

            return Ok(prescriptions);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getprescription/{prescriptionId}")]
        public async Task<ActionResult<FantasyDto>> GetPrescriptionById(int prescriptionId)
        {
            var prescription = await _unitOfWork.PrescriptionRepository.GetItemAsync(prescriptionId);
            if (prescription == null) return BadRequest("Prescription with specified Id does not exist");

            return Ok(_mapper.Map<PrescriptionDto>(prescription));
        }
    }
}
