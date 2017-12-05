using System.Collections.Generic;
using ODOC.Data.Contracts.Entities;

namespace ODOC.Data.Contracts.Interfaces
{
    public interface IOffenderSentenceRepo
    {
        IEnumerable<OffenderSentence> GetAllOffenderSentences();

        IEnumerable<OffenderSentence> GetAllOffenderSentencesForOffender(Offender offender);
    }
}
