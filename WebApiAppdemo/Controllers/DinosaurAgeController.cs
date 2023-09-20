using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiAppdemo.Models;
using WebApiAppdemo.Services;

namespace WebApiAppdemo.Controllers
{
    [Route("api/dinosaurs/{dinosaurId}/age")]
    [ApiController]
    [Authorize]
    public class DinosaurAgeController : ControllerBase
    {
        private readonly ILogger<DinosaurAgeController> _logger;
        //private readonly LocalMailService _mailService;
        private readonly DinosaurRepository _dinosaurRepo;
        private readonly IDinoaurDetailRepository _dinosaurDetailRepository;
        private readonly IMapper _mapper;

        public DinosaurAgeController(ILogger<DinosaurAgeController> logger,
            //LocalMailService mailService,
            DinosaurRepository dinosaurRepo,
            IDinoaurDetailRepository dinosaurDetailRepository,
            IMapper mapper)  /* construction injection*/
        { 
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //_mailService = mailService ?? throw new ArgumentException(nameof(mailService));
            _dinosaurRepo = dinosaurRepo;
            _dinosaurDetailRepository = dinosaurDetailRepository;
            _mapper = mapper;
        }
        
        [HttpGet("{dinosaurAgeId}")]
        public async Task<ActionResult<IEnumerable<AgeDto>>> GetDinosaurAge(int dinosaurId, int dinosaurAgeId) 
        {
                if (!await _dinosaurDetailRepository.DinosaurExistsAsync(dinosaurId))
                {
                    _logger.LogInformation($"Id {dinosaurId} wasn't found in the dinosaur repository");
                    return NotFound();
                }
            var dinosaur = await _dinosaurDetailRepository.GetDinosaurAgeAsync(dinosaurId, dinosaurAgeId);
            return Ok(_mapper.Map<AgeDto>(dinosaur));
           
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<DinosaurDto>>> GetAllDinosaurAges(int dinosaurId)
        {
                if (!await _dinosaurDetailRepository.DinosaurExistsAsync(dinosaurId))
                {
                    return NotFound();
                }
            var dinosaur = await _dinosaurDetailRepository.GetAgesAsync(dinosaurId);
            return Ok(_mapper.Map<IEnumerable<DinosaurDto>>(dinosaur));
            
            
        }
    }
}
