using AutoMapper;
using DigitizationAPI.Models;
using DigitizationAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitizationAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/individuals")]
    public class IndividualsController : ControllerBase
    {
        private readonly IIndividualRepository _individualRepository;
        private readonly IMapper _mapper;

        public IndividualsController(IIndividualRepository individualRepository, IMapper mapper)
        {
            _individualRepository = individualRepository ?? throw new ArgumentNullException(nameof(individualRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); 
        }

        [HttpPost("search")]
        public ActionResult<IEnumerable<IndividualDto>> searchIndividuals([FromBody] IndividualForSearchDto individualForSearchDto)
        {
            var individualsFromRepo = _individualRepository.searchIndividuals(individualForSearchDto.Name, individualForSearchDto.FName, individualForSearchDto.GName, individualForSearchDto.DoBYear);
            if (!individualsFromRepo.Any())
                return NotFound();
            //return Ok(_mapper.Map<IEnumerable<IndividualDto>>(individualsFromRepo));
            return Ok();
        }

        [HttpGet("{individualId}")]
        public ActionResult<IndividualDto> getIndividual(int individualId)
        {
            var individualFromRepo = _individualRepository.getIndividual(individualId);

            if (individualFromRepo == null)
                return NotFound();

            return Ok(_mapper.Map<IndividualDto>(individualFromRepo));
        }
    }
}
