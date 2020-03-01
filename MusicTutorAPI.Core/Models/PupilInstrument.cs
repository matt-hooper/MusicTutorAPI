namespace MusicTutorAPI.Core.Models
{
    public class PupilInstrument 
    {
        public int PupilId { get; set; }
        
        public Pupil Pupil { get; set; }

        public int InstrumentId { get; set; }
        
        public Instrument Instrument { get; set; }
        
    }
}