using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MusicTutorAPI.Core.Models
{
    public class Pupil 
    {
        public Pupil()
        {
            Payments = new Collection<Payment>();
            Lessons = new Collection<Lesson>();
        }
        
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int ContactID { get; set; }

        public Contact Contact { get; set; }
        public decimal CurrentLessonRate { get; set; }
        public decimal AccountBalance { get; set; } = 0.0m;
        
        public DateTime StartDate { get; set; }

        public Boolean IsActive { get; set; } = true;

        public int FrequencyInDays { get; set; }

        public byte[] Timestamp { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

    }
}