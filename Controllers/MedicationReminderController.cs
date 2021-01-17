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
    public class MedicationReminderController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicationReminderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removemedicationreminder/{Id}")]
        public async Task<ActionResult<MedicationReminderDto>> RemoveMedicationReminder(int Id)
        {
            var medicationReminder = await _unitOfWork.MedicationReminderRepository.GetItemAsync(Id);
            if (medicationReminder == null) return NotFound("Could not find requested Medication Reminder");


            _unitOfWork.MedicationReminderRepository.RemoveItem(medicationReminder);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<MedicationReminderDto>(medicationReminder));

            return BadRequest("Unable to remove Medication Reminder");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createmedicationreminder/{medicationSpreadId}")]
        public async Task<ActionResult<MedicationReminderDto>> CreateMedicationReminder(int medicationSpreadId, CreateMedicationReminderDto createMedicationReminderDto)
        {
            var medicationReminder = new MedicationReminder
            {
                MedicationDay = createMedicationReminderDto.MedicationDay,
                MedicationTime = createMedicationReminderDto.MedicationTime,
                MedicationSpread = _mapper.Map<MedicationSpread>(await _unitOfWork.MedicationSpreadRepository.GetItemAsync(medicationSpreadId))
            };

            _unitOfWork.MedicationReminderRepository.AddItem(medicationReminder);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<MedicationReminderDto>(medicationReminder));

            return BadRequest("Unable to create Medication Reminder");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getmedicationreminders/{medicationSpreadId}")]
        public async Task<ActionResult<IEnumerable<MedicationReminderDto>>> GetMedicationRemindersForMedication(int medicationSpreadId)
        {
            var medicationReminders = await _unitOfWork.MedicationReminderRepository.GetItemsAsync(ms => ms.MedicationSpread.Id == medicationSpreadId);
            if (medicationReminders == null) return NotFound("There are no Medication Reminders stored");

            return Ok(medicationReminders);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getmedicationreminder/{medicationReminderId}")]
        public async Task<ActionResult<MedicationReminderDto>> GetMedicationReminderById(int medicationReminderId)
        {
            var medicationReminder = await _unitOfWork.MedicationReminderRepository.GetItemAsync(medicationReminderId);
            if (medicationReminder == null) return BadRequest("Medication Reminder with specified Id does not exist");

            return Ok(_mapper.Map<MedicationReminderDto>(medicationReminder));
        }
    }
}
