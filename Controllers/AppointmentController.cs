﻿using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using MindYourMoodWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;

namespace MindYourMoodWeb.Controllers
{
    public class AppointmentController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeappointment/{id}")]
        public async Task<ActionResult> RemoveAppointment(int Id)
        {
            var appointment = await _unitOfWork.AppointmentsRepository.GetItemAsync(Id);
            if (appointment == null) return NotFound("Could not find requested Appointment");

            _unitOfWork.AppointmentsRepository.RemoveItem(appointment);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<AppointmentDto>(appointment));

            return BadRequest("Unable to remove Appointment");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createappointment/{userId}")]
        public async Task<ActionResult<AppointmentDto>> CreateAppointment(int userId, CreateAppointmentDto createAppointmentDto)
        {
            var appointment = new Appointment
            {
                AppointmentTime = createAppointmentDto.AppointmentTime,
                Date = createAppointmentDto.Date,
                Location = createAppointmentDto.Location,
                Notes = createAppointmentDto.Notes,
                Type = (Appointment.AppointmentType)createAppointmentDto.Type,
                WithWhom = createAppointmentDto.WithWhom,
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.AppointmentsRepository.AddItem(appointment);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<AppointmentDto>(appointment));

            return BadRequest("Unable to create Appointment");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getappointments/{userId}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsForUser(int userId)
        {
            var appointments = await _unitOfWork.AppointmentsRepository.GetItemsAsync(u => u.User.Id == userId);
            if (appointments == null) return NotFound("There are no Appointments stored");

            return Ok(appointments);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getappointment/{itemId}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointmentById(int itemId)
        {
            var appointment = await _unitOfWork.AppointmentsRepository.GetItemAsync(itemId);
            if (appointment == null) return BadRequest("Appointment with specified Id does not exist");

            return Ok(_mapper.Map<AppointmentDto>(appointment));
        }
    }
}
