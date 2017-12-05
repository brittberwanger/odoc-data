using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ODOC.Data.Contracts.Entities;
using ODOC.Data.Contracts.Interfaces;
using ODOC.Data.CSV.Helpers;

namespace ODOC.Data.CSV.Repos
{
    public class OffenderAliasRepoCSV : IOffenderAliasRepo
    {
        private readonly string _filepath;

        private const int DOC_NUMBER_INDEX = 1;

        public OffenderAliasRepoCSV(string filepath)
        {
            _filepath = filepath;
        }

        public IEnumerable<OffenderAlias> GetAllOffenderAliases()
        {
            var offenderAliasRecords = RepoHelper.GetRecords(_filepath);
            return offenderAliasRecords.Select(constructOffenderAliasEntity);
        }

        public IEnumerable<OffenderAlias> GetOffenderAliasesForOffender(Offender offender)
        {
            var offenderAliasRecords = RepoHelper.GetRecords(_filepath);
            var offenderAliasRecordsForOffender = 
                offenderAliasRecords.Where(r => aliasMatchesOffender(r, offender));

            return offenderAliasRecordsForOffender.Select(constructOffenderAliasEntity);
        }

        private OffenderAlias constructOffenderAliasEntity(string[] dataFields)
        {
            var offenderAlias = new OffenderAlias
            {
                ID = dataFields[0],
                DOCNumber = Convert.ToInt32(dataFields[DOC_NUMBER_INDEX]),
                LastName = dataFields[2],
                FirstName = dataFields[3],
                MiddleInitial = dataFields[4],
                Suffix = dataFields[5],
                DateOfBirthString = dataFields[6]
            };

            DateTime.TryParse(offenderAlias.DateOfBirthString, out DateTime dob);
            offenderAlias.DateOfBirth = dob;

            return offenderAlias;
        }

        private bool aliasMatchesOffender(string[] dataFields, Offender offender)
        {
            return offender.DOCNumber == Convert.ToInt32(dataFields[DOC_NUMBER_INDEX]);
        }
    }
}
