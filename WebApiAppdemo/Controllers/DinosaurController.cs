using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebApiAppdemo.Entities;
using WebApiAppdemo.Models;
using WebApiAppdemo.Services;

namespace WebApiAppdemo.Controllers
{

    [ApiController]
    [Route("api/dinosaurs")]
    [Authorize(Policy = "MustBeAdmin")]
    public class DinosaurController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly DinosaurRepository _dinosaurRepo;
        private readonly IDinoaurDetailRepository _dinosaurDetailRepository;
        private readonly IMapper _mapper;
        public DinosaurController(
            IMailService mailService,
            DinosaurRepository dinosaurRepo,
            IDinoaurDetailRepository dinosaurDetailRepository,
             IMapper mapper
            ) 
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _dinosaurRepo = dinosaurRepo;
            _dinosaurDetailRepository = dinosaurDetailRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DinosaurDto>>> GetDinosaurs()
        {
            var dinosaurs = await _dinosaurDetailRepository.GetDinosaursAsync();     
            return Ok(_mapper.Map<IEnumerable<DinosaurDto>>(dinosaurs));
        }   

        [HttpGet("{id}", Name = "GetDinosaurs")]
        public async Task<IActionResult> GetDinosaur(int id, bool hasAges=true)
        {
            var dinosaur = await _dinosaurDetailRepository.GetDinosaurAsync(id, hasAges);

            if(dinosaur == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DinosaurDto>(dinosaur));
        }

        [HttpPost()]
        public async Task<ActionResult<DinosaurDto>> CreateDinosaur(int id, [FromBody] DinosaurCreationDto dto)
        {
            var newDinosaur = _mapper.Map<Entities.Dinosaur>(dto);
            await _dinosaurDetailRepository.AddDinosaurAsync(id, newDinosaur);
            await _dinosaurDetailRepository.SaveChangesAsync();
            _mailService.Send($"A new entry was added with id {id}", "Addition");
            var newEntry = _mapper.Map<Models.DinosaurDto>(newDinosaur);

            return CreatedAtRoute("GetDinosaurs",
                new
                { 
                    id = newEntry.Id
                },
                newEntry);
        }

        [HttpPut("{id}")]

        public ActionResult<DinosaurDto> UpdateDinosaur(int id, DinosaurUpdateDto dto)
        {
            var dinosaur = _dinosaurRepo.Dinosaurs.FirstOrDefault(d => d.Id == id);
            if(dinosaur==null)
            {
                
                return NotFound();
            }
            dinosaur.Name = dto.Name;
            dinosaur.Description = dto.Description;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDinosaur(int id)
        {
            var dinosaur = _dinosaurRepo.Dinosaurs.FirstOrDefault(d => d.Id == id);
            if (dinosaur == null)
            {
                return NotFound();
            }
            _dinosaurRepo.Dinosaurs.Remove(dinosaur);
            return NoContent();
        }
    }
}

