using System;

namespace ODOC.Data.Contracts.Entities
{
    public class OffenderExit
    {
        public int DOCNumber { get; set; }
        public DateTime ExitDate { get; set; }
        public string ExitReason { get; set; }
    }
}
