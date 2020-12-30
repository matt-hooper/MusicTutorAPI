using GenericServices;
using Microsoft.AspNetCore.Mvc;

namespace MusicTutorAPI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly ICrudServicesAsync _service;
        public BaseApiController(ICrudServicesAsync service)
        {
            _service = service;
        }        
    }
}