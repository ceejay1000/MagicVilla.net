using AutoMapper;
using MagicVilla_WebApi.Data;
using MagicVilla_WebApi.Models;
using MagicVilla_WebApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_WebApi.Controllers
{
    [Route("api/VillaApi")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        private readonly ILogger<VillaApiController> logger;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;


        public VillaApiController(IMapper mapper, ApplicationDbContext context, ILogger<VillaApiController> logger)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<VillaDto>>> GetVillas()
        {
            this.logger.LogInformation("Get all villas");
            IEnumerable<Villa> villaList = await context.Villas.ToListAsync();
            return Ok(mapper.Map<List<VillaDto>>(villaList));
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(200, Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<VillaDto?>> GetVilla(int id)
        {
            if (id <= 0)
            {
                this.logger.LogError("Cannot find villa with Id " + 0);
                return BadRequest();
            }

            var villa = await context.Villas.FirstOrDefaultAsync(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<VillaDto>(villa));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<VillaDto?>> CreateVilla([FromBody] VillaCreateDto villaCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (villaCreateDto == null)
            {
                return BadRequest();
            }

            var existingVilla = await context.Villas.FirstOrDefaultAsync(v => v.Name.ToLower() == villaDto.Name.ToLower());

            if (existingVilla != null)
            {
                ModelState.AddModelError("CustomError", "Villa already exists");
                return BadRequest(ModelState);
            }

            Villa model = mapper.Map<Villa>(villaCreateDto);

            await context.Villas.AddAsync(model);
            await context.SaveChangesAsync();

            return CreatedAtRoute("GetVilla", new { id = model.Id }, model);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = await context.Villas.FirstOrDefaultAsync(u => u.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            context.Villas.Remove(villa);
            context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="villaDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async IActionResult UpdateVilla(int id, [FromBody] VillaUpdateDto villaUpdateDto)
        {
            if (villaUpdateDto == null || id != villaUpdateDto.Id)
            {
                return BadRequest();
            }

            // var villa = VillaStore.VillaList[id];

            //villa.Name = villaDto.Name;
            //villa.Sqft = villaDto.Sqft;
            //villa.Occupancy = villaDto.Occupancy;
            Villa model = mapper.Map<Villa>(villaUpdateDto);
            context.Villas.Update(model);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "PartialUpdateVilla")]
        public async Task<IActionResult> PartialUpdateVilla(int id, JsonPatchDocument<VillaUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return NoContent();
            }

            var villa = await context.Villas.FirstOrDefaultAsync(u => u.Id == id);

            if (villa == null)
            {
                return BadRequest();
            }

            var villaDto = mapper.Map<VillaUpdateDto>(patchDto);

            patchDto.ApplyTo(villaDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Villa model = mapper.Map<Villa>(villaDto);

            context.Villas.Add(model);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
