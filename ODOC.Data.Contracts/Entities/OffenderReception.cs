using System;

namespace ODOC.Data.Contracts.Entities
{
    public class OffenderReception
    {
        public int DOCNumber { get; set; }
        public DateTime MovementDate { get; set; }
        public string Reason { get; set; }
        public string Facility { get; set; }
    }
}
