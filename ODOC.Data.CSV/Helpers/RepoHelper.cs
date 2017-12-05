using System.IO;
using System.Linq;
using ODOC.Data.Contracts.Entities;

namespace ODOC.Data.CSV.Helpers
{
    internal static class RepoHelper
    {

        internal static string[][] GetRecords(string filepath)
        {
            return File.ReadLines(filepath).Skip(1).Select(x => x.Split(',')).ToArray();
        }
    }
}
