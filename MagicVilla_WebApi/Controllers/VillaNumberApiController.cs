using AutoMapper;
using Azure;
using MagicVilla_WebApi.Data;
using MagicVilla_WebApi.Models;
using MagicVilla_WebApi.Models.DTO;
using MagicVilla_WebApi.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicVilla_WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class VillaNumberApiController : ControllerBase
    {
        private readonly ILogger<VillaApiController> logger;
        private readonly IMapper mapper;
        private readonly IVillaNumberRepository villaNumberRepository;
        private readonly IVillaRepository villaRepository;
        protected APIResponse response;


        public VillaNumberApiController(IMapper mapper, IVillaNumberRepository villaNumberRepository,IVillaRepository villaRepository,
            ILogger<VillaApiController> logger)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.villaNumberRepository = villaNumberRepository;
            this.villaRepository = villaRepository;
            this.response = new();
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            this.logger.LogInformation("Get all villas");
            IEnumerable<VillaNumber> villaList = await villaNumberRepository.GetAllAsync();
            response.Result = mapper.Map<List<VillaNumberDto>>(villaList);
            response.StatusCode = HttpStatusCode.OK;
            return Ok(response);
    }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(200, Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<APIResponse?>> GetVillaNumber(int id)
        {
            if (id <= 0)
            {
                this.logger.LogError("Cannot find villa with Id " + 0);
                return BadRequest();
            }

            var villaNumber = await villaNumberRepository.GetAsync(u => u.VillaNo == id, true);

            if (villaNumber == null)
            {
                return NotFound();
            }

            response.Result = mapper.Map<VillaNumberDto>(villaNumber);
            response.StatusCode = HttpStatusCode.OK;
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<APIResponse?>> CreateVillaNumber([FromBody] VillaNumberCreateDto villaNumberCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (villaNumberCreateDto == null)
            {
                return BadRequest();
            }

            if (await villaRepository.GetAsync(u => u.Id == villaNumberCreateDto.VillaID) == null)
            {
                ModelState.AddModelError("CustomError", "Villa Id is invalid");
                return BadRequest(ModelState);
            }

            var existingVilla = await villaNumberRepository.GetAsync(v => v.VillaNo == villaNumberCreateDto.VillaNumber);

            if (existingVilla != null)
            {
                ModelState.AddModelError("CustomError", "Villa already exists");
                return BadRequest(ModelState);
            }

            VillaNumber model = mapper.Map<VillaNumber>(villaNumberCreateDto);

            await villaNumberRepository.CreateAsync(model);

            response.Result = model;
            response.StatusCode = HttpStatusCode.Created;

            return CreatedAtRoute("GetVilla", new { id = model.VillaNo }, response);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var villa = await villaNumberRepository.GetAsync(u => u.VillaNo == id);

                if (villa == null)
                {
                    return NotFound();
                }
                await villaNumberRepository.RemoveAsync(villa);
                response.StatusCode = HttpStatusCode.OK;
            } catch (Exception ex) {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Errors.Add(ex.Message);
            }

          
          
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="villaDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaNumberUpdateDto villaNumberUpdateDto)
        {
            if (villaNumberUpdateDto == null || id != villaNumberUpdateDto.VillaNumber)
            {
                return BadRequest();
            }

            if (await villaRepository.GetAsync(u => u.Id == villaNumberUpdateDto.VillaNumber) == null)
            {
                ModelState.AddModelError("CustomError", "Villa Id is invalid");
                return BadRequest(ModelState);
            }

            // var villa = VillaStore.VillaList[id];

            //villa.Name = villaDto.Name;
            //villa.Sqft = villaDto.Sqft;
            //villa.Occupancy = villaDto.Occupancy;
            VillaNumber model = mapper.Map<VillaNumber>(villaNumberUpdateDto);
            await villaNumberRepository.UpdateAsync(model);
            response.StatusCode = HttpStatusCode.NoContent;
            response.IsSuccess = true;
            return Ok(response);
        }

        [HttpPatch("{id:int}", Name = "PartialUpdateVilla")]
        public async Task<ActionResult<APIResponse>> PartialUpdateVilla(int id, JsonPatchDocument<VillaNumberUpdateDto> villaPatch)
        {
            if (villaPatch == null || id == 0)
            {
                return NoContent();
            }

            var villaNumber = await villaNumberRepository.GetAsync(u => u.VillaNo == id);

            if (villaNumber == null)
            {
                return BadRequest();
            }

            var villaNumberDto = mapper.Map<VillaNumberUpdateDto>(villaPatch);

            villaPatch.ApplyTo(villaNumberDto, ModelState) ;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            VillaNumber model = mapper.Map<VillaNumber>(villaNumberDto);

            await villaNumberRepository.UpdateAsync(model);

            response.StatusCode = HttpStatusCode.NotModified;
            response.IsSuccess = true;
            return Ok(response);
        }
    }
}
