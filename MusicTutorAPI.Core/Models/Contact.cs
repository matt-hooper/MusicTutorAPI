using System.Collections.Generic;

namespace MusicTutorAPI.Core.Models
{
    public class Contact 
    {
        private Contact() {}

        public Contact(string name, string email = null, string phoneNumber = null)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; private set; }
        
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string PhoneNumber { get; private set; }

        public IEnumerable<Pupil> Pupils { get; private set; }

        public void ChangeName (string name)
        {
           Name = name;
        }

        public void ChangeEmail (string email)
        {
           Email = email;
        }

        public void ChangePhoneNumber (string phoneNumber)
        {
           PhoneNumber = phoneNumber;
        }
        
    }
}