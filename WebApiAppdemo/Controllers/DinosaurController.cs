using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebApiAppdemo.Models;
using WebApiAppdemo.Services;

namespace WebApiAppdemo.Controllers
{

    [ApiController]
    [Route("api/dinosaurs")]
    public class DinosaurController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly DinosaurRepository _dinosaurRepo;
        public DinosaurController(
            IMailService mailService,
            DinosaurRepository dinosaurRepo
            ) 
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _dinosaurRepo = dinosaurRepo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<DinosaurDto>> GetDinosaurs()
        {
            return Ok(_dinosaurRepo.Dinosaurs);
        }

        [HttpGet("{id}", Name = "GetDinosaurs")]
        public ActionResult<DinosaurDto>  GetDinosaur(int id)
        {
            var dinosaur = _dinosaurRepo.Dinosaurs.FirstOrDefault(d => d.Id == id);

            if(dinosaur == null)
            {
                return NotFound();
            }
            return Ok(dinosaur);
        }

        [HttpPost()]
        public ActionResult<DinosaurDto> CreateDinosaur(int id, [FromBody] DinosaurCreationDto dto)
        {
            var dinosaur = _dinosaurRepo.Dinosaurs;
            if(dinosaur==null)
            {
                return NotFound();
            }
            id = _dinosaurRepo.Dinosaurs.Max(d => d.Id);
            var newDinosaur = new DinosaurDto()
            {
                Id = ++id,
                Name = dto.Name,
                Description = dto.Description,
            };
            dinosaur.Add(newDinosaur);
            _mailService.Send($"A new entry was added with id {id}", "Addition");
            return CreatedAtRoute("GetDinosaurs",
                new
                {
                    id = newDinosaur.Id
                },
                newDinosaur);
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

