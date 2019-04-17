using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homework3
{
    public static class Parser
    {
        public static List<T> GetData<T>(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader))
            {

                var res = csv.GetRecords<T>().ToList();

                return res;
            }
        }
    }
}
