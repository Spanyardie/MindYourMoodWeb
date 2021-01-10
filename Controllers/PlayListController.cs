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
    public class PlayListController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlayListController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        [HttpDelete("removeplaylist/{Id}")]
        public async Task<ActionResult<PlayListDto>> RemovePlayList(int Id)
        {
            var playlist = await _unitOfWork.PlayListRepository.GetItemAsync(Id);
            if (playlist == null) return NotFound("Could not find requested Play List");


            _unitOfWork.PlayListRepository.RemoveItem(playlist);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<PlayListDto>(playlist));

            return BadRequest("Unable to remove Play List");
        }

        [Authorize(Roles = "Member")]
        [HttpPost("createplaylist/{userId}")]
        public async Task<ActionResult<PlayListDto>> CreatePlayList(int userId, CreatePlayListDto createPlayListDto)
        {
            var playlist = new PlayList
            {
                Name = createPlayListDto.Name,
                TrackCount = createPlayListDto.TrackCount,
                Tracks = new Collection<Track>(),
                User = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            };

            _unitOfWork.PlayListRepository.AddItem(playlist);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<PlayListDto>(playlist));

            return BadRequest("Unable to create Play List");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getplaylists/{userId}")]
        public async Task<ActionResult<IEnumerable<PlayListDto>>> GetMoodsForThoughtRecord(int userId)
        {
            var playlists = await _unitOfWork.PlayListRepository.GetItemsAsync(u => u.User.Id == userId);
            if (playlists == null) return NotFound("There are no Play Lists stored");

            return Ok(playlists);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("getplaylist/{playlistId}")]
        public async Task<ActionResult<PlayListDto>> GetPlayListById(int playlistId)
        {
            var playlist = await _unitOfWork.PlayListRepository.GetItemAsync(playlistId);
            if (playlist == null) return BadRequest("Play List with specified Id does not exist");

            return Ok(_mapper.Map<PlayListDto>(playlist));
        }
    }
}
