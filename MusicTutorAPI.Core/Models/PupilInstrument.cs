using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MusicTutorAPI.Core.Models
{
    public class PupilInstrument 
    {
        public PupilInstrument()
        {
            Lessons = new Collection<Lesson>();
        }
        public int PupilId { get; set; }
        
        public Pupil Pupil { get; set; }

        public int InstrumentId { get; set; }
        
        public Instrument Instrument { get; set; }

        public ICollection<Lesson> Lessons { get; set; }        
    }
}