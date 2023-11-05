using Amazon.Runtime.Internal;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTApi.Dtos;
using RESTApi.Interface;
using RESTApi.Interface.Service;
using RESTApi.Models.Database;
using RESTApi.Services;
using System.Net;

namespace RESTApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/policie")]
    public class PolicieController : ControllerBase
    {
        private IMapper _mapper;

        private IPolicieService _policieService;

        public PolicieController(IMapper mapper, IMongoRepository<Policie> policieRepository)
        {
            _mapper = mapper;

            _policieService = new PolicieService(policieRepository, mapper);
        }

        [HttpPost("create")]
        public IActionResult CreatePolicie([FromBody] PolicieDto policie)
        {
            try
            {
                _policieService.AddPolicie(policie);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPolicieById(string id)
        {
            try
            {
                var res = _policieService.FindByNumber(id);

                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("vehicle/{id}")]
        public IActionResult GetPoliciByVehicle(string id)
        {
            try
            {
                var res = _policieService.FindByVehicle(id);

                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
