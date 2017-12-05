using System.Collections.Generic;
using ODOC.Data.Contracts.Entities;

namespace ODOC.Data.Contracts.Interfaces
{
    public interface IOffenderAliasRepo
    {
        IEnumerable<OffenderAlias> GetAllOffenderAliases();

        IEnumerable<OffenderAlias> GetOffenderAliasesForOffender(Offender offender);
    }
}
