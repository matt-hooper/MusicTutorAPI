using System.Collections.Generic;
using System.Threading.Tasks;
using GenericServices;
using GenericServices.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicTutorAPI.Api.Controllers.Pupils.Dtos;
using MusicTutorAPI.Core.Models;

namespace MusicTutorAPI.Api.Controllers.Pupils
{
    public class PupilController : BaseApiController
    {

        public PupilController(ICrudServicesAsync service) : base(service)
        {            
        }

        /// <summary>
        /// Gets all Pupils
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<WebApiMessageAndResult<List<Pupil>>>> GetManyAsync()
        {
            return _service.Response(await _service.ReadManyNoTracked<Pupil>().ToListAsync());
        }

        /// <summary>
        /// Gets the Pupil with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetSinglePupil")]
        public async Task<ActionResult<WebApiMessageAndResult<Pupil>>> GetSingleAsync(int id)
        {
            return _service.Response(await _service.ReadSingleAsync<Pupil>(id));
        }

        /// <summary>
        /// Creates a new Pupil and returns the created entity, with the Id value provided by the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns>If successful it returns a CreatedAtRoute response - see
        /// https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.1#implement-the-other-crud-operations
        /// </returns>
        [ProducesResponseType(typeof(CreateUpdatePupilDto), 201)] //You need this, otherwise Swagger says the success status is 200, not 201
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost]
        public async Task<ActionResult<CreateUpdatePupilDto>> PostAsync(CreateUpdatePupilDto item)
        {

            try
            {
                var result = await _service.CreateAndSaveAsync(item);
                //NOTE: to get this to work you MUST set the name of the HttpGet, e.g. [HttpGet("{id}", Name= "GetSingleTodo")],
                //on the Get you want to call, then then use the Name value in the Response.
                //Otherwise you get a "No route matches the supplied values" error.
                //see https://stackoverflow.com/questions/36560239/asp-net-core-createdatroute-failure for more on this
                return _service.Response(this, "GetSinglePupil", new { id = result.Id }, result);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Updates the supplied Pupil and returns the updated entity
        /// </summary>
        /// <param name="item"></param>
        /// <returns>If successful it returns a CreatedAtRoute response - see
        /// https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.1#implement-the-other-crud-operations
        /// </returns>
        [ProducesResponseType(typeof(CreateUpdatePupilDto), 201)] //You need this, otherwise Swagger says the success status is 200, not 201
        [ProducesResponseType(typeof(string), 400)]
        [HttpPut]
        public async Task<ActionResult<CreateUpdatePupilDto>> PutAsync(CreateUpdatePupilDto item)
        {

            try
            {
                await _service.UpdateAndSaveAsync(item);
                //NOTE: to get this to work you MUST set the name of the HttpGet, e.g. [HttpGet("{id}", Name= "GetSingleTodo")],
                //on the Get you want to call, then then use the Name value in the Response.
                //Otherwise you get a "No route matches the supplied values" error.
                //see https://stackoverflow.com/questions/36560239/asp-net-core-createdatroute-failure for more on this
                return _service.Response(this, "GetSinglePupil", new { id = item.Id }, item);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }



        /// <summary>
        /// Delete the Pupil 
        /// </summary>
        /// <returns></returns>
        // DELETE api/<type>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiMessageOnly>> DeleteItemAsync(int id)
        {
            await _service.DeleteAndSaveAsync<Pupil>(id);
            return _service.Response();
        }
    }
}