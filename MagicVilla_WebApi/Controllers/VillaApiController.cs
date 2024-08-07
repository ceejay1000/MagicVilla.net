﻿using AutoMapper;
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
    [Route("api/VillaApi")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        private readonly ILogger<VillaApiController> logger;
        private readonly IMapper mapper;
        private readonly IVillaRepository villaRepository;
        protected APIResponse response;


        public VillaApiController(IMapper mapper, IVillaRepository villaRepository, ILogger<VillaApiController> logger)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.villaRepository = villaRepository;
            this.response = new();
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            this.logger.LogInformation("Get all villas");
            IEnumerable<Villa> villaList = await villaRepository.GetAllAsync();
            response.Result = mapper.Map<List<VillaDto>>(villaList);
            response.StatusCode = HttpStatusCode.OK;
            return Ok(response);
    }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(200, Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<APIResponse?>> GetVilla(int id)
        {
            if (id <= 0)
            {
                this.logger.LogError("Cannot find villa with Id " + 0);
                return BadRequest();
            }

            var villa = await villaRepository.GetAsync(u => u.Id == id, true);

            if (villa == null)
            {
                return NotFound();
            }

            response.Result = mapper.Map<VillaDto>(villa);
            response.StatusCode = HttpStatusCode.OK;
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<APIResponse?>> CreateVilla([FromBody] VillaCreateDto villaCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (villaCreateDto == null)
            {
                return BadRequest();
            }

            var existingVilla = await villaRepository.GetAsync(v => v.Name == villaCreateDto.Name);

            if (existingVilla != null)
            {
                ModelState.AddModelError("CustomError", "Villa already exists");
                return BadRequest(ModelState);
            }

            Villa model = mapper.Map<Villa>(villaCreateDto);

            await villaRepository.CreateAsync(model);

            response.Result = model;
            response.StatusCode = HttpStatusCode.Created;

            return CreatedAtRoute("GetVilla", new { id = model.Id }, response);
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

                var villa = await villaRepository.GetAsync(u => u.Id == id);

                if (villa == null)
                {
                    return NotFound();
                }
                await villaRepository.RemoveAsync(villa);
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
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDto villaUpdateDto)
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
            await villaRepository.UpdateAsync(model);
            response.StatusCode = HttpStatusCode.NoContent;
            response.IsSuccess = true;
            return Ok(response);
        }

        [HttpPatch("{id:int}", Name = "PartialUpdateVilla")]
        public async Task<ActionResult<APIResponse>> PartialUpdateVilla(int id, JsonPatchDocument<VillaUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return NoContent();
            }

            var villa = await villaRepository.GetAsync(u => u.Id == id);

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

            await villaRepository.UpdateAsync(model);

            response.StatusCode = HttpStatusCode.NotModified;
            response.IsSuccess = true;
            return Ok(response);
        }
    }
}
