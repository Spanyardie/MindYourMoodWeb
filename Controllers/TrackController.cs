using MindYourMoodWeb.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;

namespace MindYourMoodWeb.Controllers
{
    public class TrackController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TrackController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removetrack/{Id}")]
        public async Task<ActionResult<TrackDto>> RemoveTrack(int Id)
        {
            var track = await _unitOfWork.TrackRepository.GetItemAsync(Id);
            if (track == null) return NotFound("Could not find requested Track");

            _unitOfWork.TrackRepository.RemoveItem(track);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<TrackDto>(track));

            return BadRequest("Unable to remove Track");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createtrack/{playListId}")]
        public async Task<ActionResult<TrackDto>> CreateTrack(int playListId, CreateTrackDto createTrackDto)
        {
            var track = new Track
            {
                Name = createTrackDto.Name,
                Artist = createTrackDto.Artist,
                Duration = createTrackDto.Duration,
                OrderNumber = createTrackDto.OrderNumber,
                Uri = createTrackDto.Uri,
                PlayList = _mapper.Map<PlayList>(await _unitOfWork.PlayListRepository.GetItemAsync(playListId))
            };

            _unitOfWork.TrackRepository.AddItem(track);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<TrackDto>(track));

            return BadRequest("Unable to create Track");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("gettracks/{playListId}")]
        public async Task<ActionResult<IEnumerable<TrackDto>>> GetMoodsForThoughtRecord(int playListId)
        {
            var tracks = await _unitOfWork.TrackRepository.GetItemsAsync(pl => pl.PlayList.Id == playListId);
            if (tracks == null) return NotFound("There are no Tracks stored");

            return Ok(tracks);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("gettrack/{trackId}")]
        public async Task<ActionResult<TrackDto>> GetTrackById(int trackId)
        {
            var track = await _unitOfWork.TrackRepository.GetItemAsync(trackId);
            if (track == null) return BadRequest("Track with specified Id does not exist");

            return Ok(_mapper.Map<TrackDto>(track));
        }
    }
}
