using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GenericServices;
using GenericServices.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicTutorAPI.Core.Dtos;
using MusicTutorAPI.Core.Models;
using MusicTutorAPI.Data;

namespace MusicTutorAPI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentController : ControllerBase
    {
        
        private readonly ILogger<InstrumentController> _logger;
        private readonly MusicTutorAPIDbContext _context;

        public InstrumentController(ILogger<InstrumentController> logger, MusicTutorAPIDbContext musicTutorAPIDbContext)
        {
            _logger = logger;
            _context = musicTutorAPIDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiMessageAndResult<List<Instrument>>>> GetManyAsync([FromServices]ICrudServices service)
        {
            return service.Response(await service.ReadManyNoTracked<Instrument>().ToListAsync());
        }

        /// <summary>
        /// Gets the TodoItemHybrid with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetSingleInstrument")]
        public async Task<ActionResult<WebApiMessageAndResult<Instrument>>> GetSingleAsync(int id, [FromServices]ICrudServicesAsync service)
        {
            return service.Response(await service.ReadSingleAsync<Instrument>(id));
        }


        /// <summary>
        /// Creates a new item and returns the created entity, with the Id value provided by the database
        /// NOTE: to show how business logic might work I added extra validation (name can't end with !) in the business logic
        /// </summary>
        /// <param name="item"></param>
        /// <param name="service"></param>
        /// <returns>If successful it returns a CreatedAtRoute response - see
        /// https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.1#implement-the-other-crud-operations
        /// </returns>
        [ProducesResponseType(typeof (CreateInstrumentDto), 201)] //You need this, otherwise Swagger says the success status is 200, not 201
        [HttpPost]
        public async Task<ActionResult<CreateInstrumentDto>> PostAsync(CreateInstrumentDto item, [FromServices]ICrudServicesAsync service)
        {
                        
            try 
            {
                var result = await service.CreateAndSaveAsync(item);
                //NOTE: to get this to work you MUST set the name of the HttpGet, e.g. [HttpGet("{id}", Name= "GetSingleTodo")],
                //on the Get you want to call, then then use the Name value in the Response.
                //Otherwise you get a "No route matches the supplied values" error.
                //see https://stackoverflow.com/questions/36560239/asp-net-core-createdatroute-failure for more on this
                return service.Response(this, "GetSingleInstrument", new { id = result.Id },  result);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}