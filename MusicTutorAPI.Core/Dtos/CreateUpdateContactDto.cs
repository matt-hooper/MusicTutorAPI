using System.ComponentModel.DataAnnotations;
using GenericServices;
using Microsoft.AspNetCore.Mvc;
using MusicTutorAPI.Core.Models;

namespace MusicTutorAPI.Core.Dtos
{
    public class CreateUpdateContactDto : ILinkToEntity<Contact>
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}