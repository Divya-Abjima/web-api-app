using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiAppdemo.Models;
using WebApiAppdemo.Services;

namespace WebApiAppdemo.Controllers
{
    [Route("api/dinosaurs/{dinosaurId}/age")]
    [ApiController]
    public class DinosaurAgeController : ControllerBase
    {
        private readonly ILogger<DinosaurAgeController> _logger;
        private readonly LocalMailService _mailService;
        private readonly DinosaurRepository _dinosaurRepo;
        public DinosaurAgeController(ILogger<DinosaurAgeController> logger,
            LocalMailService mailService,
            DinosaurRepository dinosaurRepo)  /* construction injection*/
        { 
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentException(nameof(mailService));
            _dinosaurRepo = dinosaurRepo;
        }
        
        [HttpGet("{dinosaurAgeId}")]
        public ActionResult<IEnumerable<AgeDto>> GetDinosaurAge(int dinosaurId, int dinosaurAgeId) 
        {
                var dinosaur = _dinosaurRepo.Dinosaurs.FirstOrDefault(d => d.Id == dinosaurId);
                if (dinosaur == null)
                {
                    _logger.LogInformation($"Id {dinosaurId} wasn't found in the dinosaur repository");
                    return NotFound();
                }
                var age = dinosaur.Age.FirstOrDefault(a => a.AgeId == dinosaurAgeId);
                if (age == null)
                {
                    throw new Exception("Exception");

                }
                return Ok(age);
           
        }
        [HttpGet]

        public ActionResult<IEnumerable<AgeDto>> GetAllDinosaurAges(int dinosaurId)
        {
       
                var dinosaurid = _dinosaurRepo.Dinosaurs.FirstOrDefault(d => d.Id == dinosaurId);
                var dinosaur = _dinosaurRepo.Dinosaurs.GroupBy(d => d.TotalAges == 1);
                if (dinosaurid == null)
                {
                    _logger.LogInformation($"Data not found at{dinosaurId}");
                    return NotFound();
                }
               return Ok(dinosaur);
            
            
        }
    }
}
