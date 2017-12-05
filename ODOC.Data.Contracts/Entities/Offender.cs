using System;

namespace ODOC.Data.Contracts.Entities
{
    public class Offender
    {
        public int DOCNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string Suffix { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string DateOfBirthString { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ReceptionDateString { get; set; }
        public DateTime ReceptionDate { get; set; }
        public string CurrentFacility { get; set; }
        public string Status { get; set; }
    }
}
