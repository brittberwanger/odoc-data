using System.Collections.Generic;
using ODOC.Data.Contracts.Entities;

namespace ODOC.Data.Contracts.Interfaces
{
    public interface IOffenderReceptionRepo
    {
        IEnumerable<OffenderReception> GetAllOffenderReceptions();

        IEnumerable<OffenderReception> GetAllOffenderReceptionsForOffender(Offender offender);
    }
}
