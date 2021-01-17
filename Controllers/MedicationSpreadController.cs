using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MindYourMoodWeb.Entities.MedicationSpread;

namespace MindYourMoodWeb.Controllers
{
    public class MedicationSpreadController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicationSpreadController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removemedicationspread/{Id}")]
        public async Task<ActionResult<MedicationSpreadDto>> RemoveMedicationSpread(int Id)
        {
            var medicationSpread = await _unitOfWork.MedicationSpreadRepository.GetItemAsync(Id);
            if (medicationSpread == null) return NotFound("Could not find requested Medication Spread");


            _unitOfWork.MedicationSpreadRepository.RemoveItem(medicationSpread);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<MedicationSpreadDto>(medicationSpread));

            return BadRequest("Unable to remove Medication Spread");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createmedicationspread/{medicationId}")]
        public async Task<ActionResult<MedicationDto>> CreateMedicationSpread(int medicationId, CreateMedicationSpreadDto createMedicationSpreadDto)
        {
            var medicationSpread = new MedicationSpread
            {
                Dosage = createMedicationSpreadDto.Dosage,
                Medication = _mapper.Map<Medication>(await _unitOfWork.MedicationRepository.GetItemAsync(medicationId)),
                MedicationTakeReminder = new MedicationReminder(),
                MedicationTime = new MedicationTime(),
                Relevance = (FoodRelevance)createMedicationSpreadDto.Relevance
            };

            _unitOfWork.MedicationSpreadRepository.AddItem(medicationSpread);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<MedicationSpreadDto>(medicationSpread));

            return BadRequest("Unable to create Medication Spread");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getmedicationspreads/{medicationId}")]
        public async Task<ActionResult<IEnumerable<MedicationSpreadDto>>> GetMedicationSpreadsForMedication(int medicationId)
        {
            var medicationSpreads = await _unitOfWork.MedicationSpreadRepository.GetItemsAsync(m => m.Medication.Id == medicationId);
            if (medicationSpreads == null) return NotFound("There are no Medication Spreads stored");

            return Ok(medicationSpreads);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getmedicationspread/{medicationId}")]
        public async Task<ActionResult<MedicationSpreadDto>> GetMedicationSpreadById(int medicationId)
        {
            var medicationSpread = await _unitOfWork.MedicationSpreadRepository.GetItemAsync(medicationId);
            if (medicationSpread == null) return BadRequest("Medication Spread with specified Id does not exist");

            return Ok(_mapper.Map<MedicationSpreadDto>(medicationSpread));
        }
    }
}
