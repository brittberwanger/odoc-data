using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ODOC.Data.Contracts.Entities;
using ODOC.Data.Contracts.Interfaces;
using ODOC.Data.CSV.Helpers;

namespace ODOC.Data.CSV.Repos
{
    public class OffenderRepoCSV : IOffenderRepo
    {
        private readonly string _filepath;

        public OffenderRepoCSV(string filepath)
        {
            _filepath = filepath;
        }

        public IEnumerable<Offender> GetAllOffenders()
        {
            var offenderRecords = RepoHelper.GetRecords(_filepath);
            return offenderRecords.Select(constructOffenderEntity);
        }

        private Offender constructOffenderEntity(string[] dataFields)
        {
            var offender = new Offender
            {
                DOCNumber = Convert.ToInt32(dataFields[0]),
                LastName = dataFields[1],
                FirstName = dataFields[2],
                MiddleInitial = dataFields[3],
                Suffix = dataFields[4],
                Race = dataFields[5],
                Gender = dataFields[6],
                HairColor = dataFields[7],
                EyeColor = dataFields[8],
                Height = dataFields[9],
                Weight = dataFields[10],
                DateOfBirthString = dataFields[11],
                ReceptionDateString = dataFields[12],
                CurrentFacility = dataFields.Length == 15
                    ? dataFields[13]
                    : string.Join("; ", dataFields[13], dataFields[14]),
                Status = dataFields.Length == 15
                    ? dataFields[14]
                    : dataFields[15]
            };


            DateTime.TryParse(offender.DateOfBirthString, out DateTime dob);
            offender.DateOfBirth = dob;

            DateTime.TryParse(offender.ReceptionDateString, out DateTime rd);
            offender.ReceptionDate = rd;

            return offender;
        }
    }
}
