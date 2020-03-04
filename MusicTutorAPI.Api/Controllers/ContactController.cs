using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicTutorAPI.Core.Models;
using MusicTutorAPI.Data;

namespace MusicTutorAPI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        
        private readonly ILogger<ContactController> _logger;
        private readonly MusicTutorAPIDbContext _context;

        public ContactController(ILogger<ContactController> logger, MusicTutorAPIDbContext musicTutorAPIDbContext)
        {
            _logger = logger;
            _context = musicTutorAPIDbContext;
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _context.Set<Contact>().ToList();
        }        
    }
}