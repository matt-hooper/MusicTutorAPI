using MusicTutorAPI.Api.Controllers.Instruments.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace MusicTutorAPI.Api.Controllers.Instruments.Dtos
{
    public class CreateInstrumentDtoExample : IExamplesProvider<CreateInstrumentDto>
    {
        public CreateInstrumentDto GetExamples()
        {
            return new CreateInstrumentDto()
            {
                Name = "Triangle"
            };
        }
    }
}