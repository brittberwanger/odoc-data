using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ODOC.Data.Contracts.Entities;
using ODOC.Data.Contracts.Interfaces;
using ODOC.Data.CSV.Helpers;

namespace ODOC.Data.CSV.Repos
{
    public class OffenderExitRepoCSV : IOffenderExitRepo
    {
        private readonly string _filepath;

        private const int DOC_NUMBER_INDEX = 0;

        public OffenderExitRepoCSV(string filepath)
        {
            _filepath = filepath;
        }

        public IEnumerable<OffenderExit> GetAllOffenderExits()
        {
            var offenderExitRecords = RepoHelper.GetRecords(_filepath);
            return offenderExitRecords.Select(constructOffenderExitEntity);
        }

        public IEnumerable<OffenderExit> GetAllOffenderExitsForOffender(Offender offender)
        {
            var offenderExitRecords = RepoHelper.GetRecords(_filepath);
            var offenderExitRecordsForOffender = offenderExitRecords.Where(r => exitMatchesOffender(r, offender));

            return offenderExitRecordsForOffender.Select(constructOffenderExitEntity);
        }

        private OffenderExit constructOffenderExitEntity(string[] dataFields)
        {
            return new OffenderExit
            {
                DOCNumber = Convert.ToInt32(dataFields[DOC_NUMBER_INDEX]),
                ExitDate = DateTime.Parse(dataFields[1]),
                ExitReason = dataFields[2]
            };
        }

        private bool exitMatchesOffender(string[] dataFields, Offender offender)
        {
            return offender.DOCNumber == Convert.ToInt32(dataFields[DOC_NUMBER_INDEX]);
        }
    }
}
