using System;
using System.Collections.Generic;
using System.Linq;
using ODOC.Data.Contracts.Entities;
using ODOC.Data.Contracts.Interfaces;
using ODOC.Data.CSV.Helpers;

namespace ODOC.Data.CSV.Repos
{
    public class OffenderSentenceRepoCSV : IOffenderSentenceRepo
    {
        private readonly string _filepath;

        private const int DOC_NUMBER_INDEX = 1;

        public OffenderSentenceRepoCSV(string filepath)
        {
            _filepath = filepath;
        }

        public IEnumerable<OffenderSentence> GetAllOffenderSentences()
        {
            var offenderSentenceRecords = RepoHelper.GetRecords(_filepath);
            return offenderSentenceRecords.Select(constructOffenderSentenceEntity);
        }

        public IEnumerable<OffenderSentence> GetAllOffenderSentencesForOffender(Offender offender)
        {
            var offenderSentenceRecords = RepoHelper.GetRecords(_filepath);
            var offenderSentenceRecordsForOffender =
                offenderSentenceRecords.Where(r => sentenceMatchesOffender(r, offender));

            return offenderSentenceRecordsForOffender.Select(constructOffenderSentenceEntity);
        }

        private OffenderSentence constructOffenderSentenceEntity(string[] dataFields)
        {
            var offenderSentence = new OffenderSentence();

            offenderSentence.ID = Convert.ToInt32(dataFields[0]);
            offenderSentence.DOCNumber = Convert.ToInt32(dataFields[1]);
            offenderSentence.OrderID = Convert.ToInt32(dataFields[2]);
            offenderSentence.ChargeSequence = Convert.ToInt32(dataFields[3]);
            offenderSentence.CRFNumber = dataFields[4];
            offenderSentence.ConvictedDate = DateTime.Parse(dataFields[5]);
            offenderSentence.Court = dataFields[6];
            offenderSentence.StatuteCode = dataFields[7];
            offenderSentence.OffenceDescription = dataFields[8];
            offenderSentence.OffenceComment = dataFields[9];
            offenderSentence.SentenceTermCode = dataFields[10];
            offenderSentence.Years = Convert.ToInt32(dataFields[11]);
            offenderSentence.Months = Convert.ToInt32(dataFields[12]);
            offenderSentence.Days = Convert.ToInt32(dataFields[13]);
            offenderSentence.SentenceTerm = dataFields[14];
            offenderSentence.StartDate = DateTime.Parse(dataFields[15]);
            offenderSentence.EndDate = DateTime.Parse(dataFields[16]);
            offenderSentence.CountNumber = Convert.ToInt32(dataFields[17]);
            offenderSentence.OrderCode = dataFields[18];
            offenderSentence.ConsecutiveToCount = Convert.ToInt32(dataFields[19]);
            offenderSentence.ChargeStatus = dataFields[20];

            return offenderSentence;
        }

        private bool sentenceMatchesOffender(string[] dataFields, Offender offender)
        {
            return offender.DOCNumber == Convert.ToInt32(dataFields[DOC_NUMBER_INDEX]);
        }
    }
}
