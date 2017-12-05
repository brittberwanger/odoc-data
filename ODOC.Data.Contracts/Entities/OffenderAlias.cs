using System;

namespace ODOC.Data.Contracts.Entities
{
    public class OffenderAlias
    {
        public string ID { get; set; }
        public int DOCNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string Suffix { get; set; }
        public string DateOfBirthString { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
