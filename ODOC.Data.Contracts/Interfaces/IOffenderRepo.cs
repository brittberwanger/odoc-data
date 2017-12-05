using System.Collections.Generic;
using ODOC.Data.Contracts.Entities;

namespace ODOC.Data.Contracts.Interfaces
{
    public interface IOffenderRepo
    {
        IEnumerable<Offender> GetAllOffenders();
    }
}
