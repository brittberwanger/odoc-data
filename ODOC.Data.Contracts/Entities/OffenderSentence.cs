using System;
using System.Runtime.CompilerServices;

namespace ODOC.Data.Contracts.Entities
{
    public class OffenderSentence
    {
        public int ID { get; set; }
        public int DOCNumber { get; set; }
        public int OrderID { get; set; }
        public int ChargeSequence { get; set; }
        public string CRFNumber { get; set; }
        public DateTime ConvictedDate { get; set; }
        public string Court { get; set; }
        public string StatuteCode { get; set; }
        public string OffenceDescription { get; set; }
        public string OffenceComment { get; set; }
        public string SentenceTermCode { get; set; }
        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }
        public string SentenceTerm { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CountNumber { get; set; }
        public string OrderCode { get; set; }
        public int ConsecutiveToCount { get; set; }
        public string ChargeStatus { get; set; }
    }
}
