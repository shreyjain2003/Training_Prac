namespace Q05_LogAnalyzer.Models
{
    public class ErrorSummary
    {
        public string ErrorCode { get; }
        public int Count { get; }

        public ErrorSummary(string errorCode, int count)
        {
            ErrorCode = errorCode;
            Count = count;
        }
    }
}
