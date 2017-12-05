using System;
using System.Collections.Generic;
using System.Linq;
using ODOC.Data.Contracts.Entities;
using ODOC.Data.Contracts.Interfaces;
using ODOC.Data.CSV.Helpers;

namespace ODOC.Data.CSV.Repos
{
    public class OffenderReceptionRepoCSV : IOffenderReceptionRepo
    {
        private readonly string _filepath;

        private const int DOC_NUMBER_INDEX = 0;

        public OffenderReceptionRepoCSV(string filepath)
        {
            _filepath = filepath;
        }

        public IEnumerable<OffenderReception> GetAllOffenderReceptions()
        {
            var offenderRecptionRecords = RepoHelper.GetRecords(_filepath);
            return offenderRecptionRecords.Select(constructOffenderReceptionEntity);
        }

        public IEnumerable<OffenderReception> GetAllOffenderReceptionsForOffender(Offender offender)
        {
            var offenderRecptionRecords = RepoHelper.GetRecords(_filepath);
            var offenderReceptionRecordsForOffender =
                offenderRecptionRecords.Where(r => receptionMatchesOffender(r, offender));

            return offenderReceptionRecordsForOffender.Select(constructOffenderReceptionEntity);
        }

        private OffenderReception constructOffenderReceptionEntity(string[] dataFields)
        {
            return new OffenderReception
            {
                DOCNumber = Convert.ToInt32(dataFields[0]),
                MovementDate = DateTime.Parse(dataFields[1]),
                Reason = dataFields[2],
                Facility = dataFields[3]
            };
        }

        private bool receptionMatchesOffender(string[] dataFields, Offender offender)
        {
            return offender.DOCNumber == Convert.ToInt32(dataFields[DOC_NUMBER_INDEX]);
        }
    }
}
