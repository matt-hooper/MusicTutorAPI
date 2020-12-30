using System;
using System.ComponentModel.DataAnnotations;
using GenericServices;
using MusicTutorAPI.Core.Models;
using Swashbuckle.AspNetCore.Filters;

namespace MusicTutorAPI.Api.Controllers.Pupils.Dtos
{
    public class CreateUpdatePupilDtoExample : IExamplesProvider<CreateUpdatePupilDto>
    {
        public CreateUpdatePupilDto GetExamples()
        {
            return new CreateUpdatePupilDto()
            {
                Name = "Mary",
                ContactID = null,
                CurrentLessonRate = 15.0M,
                AccountBalance = 0.0M,
                StartDate = DateTime.Now.AddDays(7),
                IsActive = true,
                FrequencyInDays = 7
            };
        }
    }
}