using System.Collections.Generic;
using ODOC.Data.Contracts.Entities;

namespace ODOC.Data.Contracts.Interfaces
{
    public interface IOffenderExitRepo
    {
        IEnumerable<OffenderExit> GetAllOffenderExits();

        IEnumerable<OffenderExit> GetAllOffenderExitsForOffender(Offender offender);
    }
}
