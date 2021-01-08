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
    public class MedicationTimeController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicationTimeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removemedicationtime/{Id}")]
        public async Task<ActionResult<MedicationTimeDto>> RemoveMedicationTime(int Id)
        {
            var medicationTime = await _unitOfWork.MedicationTimeRepository.GetMedicationTimeAsync(Id);
            if (medicationTime == null) return NotFound("Could not find requested Medication Time");


            _unitOfWork.MedicationTimeRepository.RemoveMedicationTime(medicationTime);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<MedicationTimeDto>(medicationTime));

            return BadRequest("Unable to remove Medication Time");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createmedicationtime/{medicationSpreadId}")]
        public async Task<ActionResult<MedicationTimeDto>> CreateMedicationTime(int medicationSpreadId, CreateMedicationTimeDto createMedicationTimeDto)
        {
            var medicationSpread = await _unitOfWork.MedicationSpreadRepository.GetMedicationSpreadAsync(medicationSpreadId);
            if (medicationSpread == null) return BadRequest("Could not identify the Spread to add Time to");

            var medicationTime = new MedicationTime
            {
                Spread = medicationSpread,
                Time = createMedicationTimeDto.Time,
                TakenTime = createMedicationTimeDto.TakenTime,
                Medication = medicationSpread.Medication
            };

            _unitOfWork.MedicationTimeRepository.AddMedicationTime(medicationTime);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<MedicationTimeDto>(medicationTime));

            return BadRequest("Unable to create Medication Time");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getmedicationtimes/{medicationSpreadId}")]
        public async Task<ActionResult<IEnumerable<MedicationTimeDto>>> GetMedicationTimesForMedication(int medicationSpreadId)
        {
            var medicationTimes = await _unitOfWork.MedicationTimeRepository.GetMedicationTimesAsync(medicationSpreadId);
            if (medicationTimes == null) return NotFound("There are no Medication Times stored");

            return Ok(medicationTimes);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getmedicationtime/{medicationTimeId}")]
        public async Task<ActionResult<MedicationTimeDto>> GetMedicationTimeById(int medicationTimeId)
        {
            var medicationTime = await _unitOfWork.MedicationTimeRepository.GetMedicationTimeAsync(medicationTimeId);
            if (medicationTime == null) return BadRequest("Medication Time with specified Id does not exist");

            return Ok(_mapper.Map<MedicationTimeDto>(medicationTime));
        }
    }
}
