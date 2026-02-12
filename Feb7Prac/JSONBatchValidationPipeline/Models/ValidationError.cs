namespace Q07_JSONValidation.Models
{
    public class ValidationError
    {
        public int RecordIndex { get; }
        public string Message { get; }

        public ValidationError(int recordIndex, string message)
        {
            RecordIndex = recordIndex;
            Message = message;
        }
    }
}
