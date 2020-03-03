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
        public IEnumerable<Instrument> Get()
        {
            //var instuments = new List<Instrument> { new Instrument{ Id = 1, Name = "Piano"}, new Instrument{ Id = 2, Name = "Flute"} };
            return _context.Set<Instrument>().ToList();
        }

        // [HttpPost]
        // public ActionResult<Instrument> PostInstrument(Instrument instrument)
        // {
        //     _context.Instruments.Add(instrument);
        //     _context.SaveChanges();

        //     return CreatedAtAction("GetInstrument", new { id = instrument.Id }, instrument);
        // }
    }
}