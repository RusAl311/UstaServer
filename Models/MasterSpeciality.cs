namespace UstaApi.Models
{
    public class MasterSpeciality
    {
        public int  MasterId { get; set; }
        public Master Master { get; set; }
        
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }
    }
}