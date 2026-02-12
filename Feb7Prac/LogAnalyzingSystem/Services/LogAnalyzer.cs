using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Q05_LogAnalyzer.Models;

namespace Q05_LogAnalyzer.Services
{
    public class LogAnalyzer
    {
        private static readonly Regex ErrorRegex =
            new Regex(@"ERR\d+", RegexOptions.Compiled);

        public IEnumerable<ErrorSummary> GetTopErrors(string filePath, int topN)
        {
            var errorCounts = new Dictionary<string, int>();

            using (var reader = new StreamReader(filePath))
            {
                string? line;

                while ((line = reader.ReadLine()) != null)
                {
                    var matches = ErrorRegex.Matches(line);

                    foreach (Match match in matches)
                    {
                        string errorCode = match.Value;

                        if (!errorCounts.ContainsKey(errorCode))
                            errorCounts[errorCode] = 0;

                        errorCounts[errorCode]++;
                    }
                }
            }

            return errorCounts
                .OrderByDescending(e => e.Value)
                .Take(topN)
                .Select(e => new ErrorSummary(e.Key, e.Value));
        }
    }
}

