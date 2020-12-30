using System;
using System.ComponentModel.DataAnnotations;
using GenericServices;
using MusicTutorAPI.Core.Models;

namespace MusicTutorAPI.Api.Controllers.Pupils.Dtos
{
    public class CreateUpdatePupilDto : ILinkToEntity<Pupil>
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public int? ContactID { get; set; }

        public decimal CurrentLessonRate { get; set; }
        public decimal AccountBalance { get; set; } = 0.0m;

        public DateTime StartDate { get; set; }

        public Boolean IsActive { get; set; } = true;

        public int FrequencyInDays { get; set; }
    }
}