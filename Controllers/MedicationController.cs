using MindYourMoodWeb.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.ObjectModel;

namespace MindYourMoodWeb.Controllers
{
    public class MedicationController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [Authorize(Roles = "Member")]
        [HttpDelete("removemedication/{Id}")]
        public async Task<ActionResult<MedicationDto>> RemoveMedication(int Id)
        {
            var medication = await _unitOfWork.MedicationRepository.GetItemAsync(Id);
            if (medication == null) return NotFound("Could not find requested Medication");


            _unitOfWork.MedicationRepository.RemoveItem(medication);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<MedicationDto>(medication));

            return BadRequest("Unable to remove Medication");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createmedication/{prescriptionId}")]
        public async Task<ActionResult<MedicationDto>> CreateMedication(int prescriptionId, CreateMedicationDto createMedicationDto)
        {
            var medication = new Medication
            {
                MedicationName = createMedicationDto.MedicationName,
                TotalDailyDosage = createMedicationDto.TotalDailyDosage,
                MedicationSpreads = new Collection<MedicationSpread>(),
                Prescription = await _unitOfWork.PrescriptionRepository.GetItemAsync(prescriptionId)
            };

            _unitOfWork.MedicationRepository.AddItem(medication);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<MedicationDto>(medication));

            return BadRequest("Unable to create Medication");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getmedications/{prescriptionId}")]
        public async Task<ActionResult<IEnumerable<MedicationDto>>> GetMedicationsForPrescription(int prescriptionId)
        {
            var medications = await _unitOfWork.MedicationRepository.GetItemsAsync(p => p.Prescription.Id == prescriptionId);
            if (medications == null) return NotFound("There are no Medications stored");

            return Ok(medications);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getmedication/{medicationId}")]
        public async Task<ActionResult<MedicationDto>> GetMedicationById(int medicationId)
        {
            var medication = await _unitOfWork.MedicationRepository.GetItemAsync(medicationId);
            if (medication == null) return BadRequest("Medication with specified Id does not exist");

            return Ok(_mapper.Map<MedicationDto>(medication));
        }
    }
}
