using System.ComponentModel.DataAnnotations;
using GenericServices;
using Microsoft.AspNetCore.Mvc;
using MusicTutorAPI.Core.Models;

namespace MusicTutorAPI.Api.Controllers.Instruments.Dtos
{
    public class CreateInstrumentDto : ILinkToEntity<Instrument>
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }        
        
    }
}