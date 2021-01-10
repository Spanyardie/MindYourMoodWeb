using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MindYourMoodWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.DTOs;

namespace MindYourMoodWeb.Controllers
{
    public class AppointmentQuestionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentQuestionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeappointmentquestion/{id}")]
        public async Task<ActionResult> RemoveAppointmentQuestion(int Id)
        {
            var appointmentQuestion = await _unitOfWork.AppointmentQuestionsRepository.GetItemAsync(Id);
            if (appointmentQuestion == null) return NotFound("Could not find requested Appointment question");


            _unitOfWork.AppointmentQuestionsRepository.RemoveItem
                (_mapper.Map<AppointmentQuestion>(appointmentQuestion));

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<AppointmentQuestionDto>(appointmentQuestion));

            return BadRequest("Unable to remove Appointment question");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createappointmentquestion/{userId}")]
        public async Task<ActionResult<AppointmentQuestionDto>> CreateAppointmentQuestion(int userId, CreateAppointmentQuestionDto createAppointmentQuestionDto)
        {
            var appointmentQuestion = new AppointmentQuestion
            {
                Question = createAppointmentQuestionDto.Question,
                Answer = createAppointmentQuestionDto.Answer,
                Appointment = await _unitOfWork.AppointmentsRepository.GetItemAsync(createAppointmentQuestionDto.AppointmentId)
            };

            _unitOfWork.AppointmentQuestionsRepository.AddItem(appointmentQuestion);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<AppointmentQuestionDto>(appointmentQuestion));

            return BadRequest("Unable to create Appointment question");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getappointmentquestions/{appointmentId}")]
        public async Task<ActionResult<IEnumerable<AppointmentQuestionDto>>> GetAppointmentQuestionsForAppointment(int appointmentId)
        {
            var appointmentQuestions = await _unitOfWork.AppointmentQuestionsRepository.GetItemsAsync(a => a.Id == appointmentId);
            if (appointmentQuestions == null) return NotFound("There are no Appointment Questions stored");

            return Ok(appointmentQuestions);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getappointmentquestion/{itemId}")]
        public async Task<ActionResult<AppointmentQuestionDto>> GetAppointmentQuestionById(int itemId)
        {
            var appointmentQuestion = await _unitOfWork.AppointmentQuestionsRepository.GetItemAsync(itemId);
            if (appointmentQuestion == null) return BadRequest("Appointment Question with specified Id does not exist");

            return Ok(_mapper.Map<AppointmentQuestionDto>(appointmentQuestion));
        }
    }
}
