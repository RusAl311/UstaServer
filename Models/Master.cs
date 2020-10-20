using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UstaApi.Models
{
    public class Master
    {
        public int MasterId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string FatherName { get; set; }

        public string FIN { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        public int WorkExperience { get; set; }

        public int PhoneNumber { get; set; }

        public int PhoneNumberExtra { get; set; }

        public string ImageUrl { get; set; }
        
        //location
        //oz ustalarimiz / kenar ustalar

        public List<MasterSpeciality> MasterSpecialities { get; set; }
    }
}