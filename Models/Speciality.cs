using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UstaApi.Models
{
    public class Speciality
    {
        public int SpecialityId { get; set; }
        public string Name { get; set; }
        public string Description  { get; set; }

        [JsonIgnore]
        public List<MasterSpeciality> MasterSpecialities { get; set; }

    }
}