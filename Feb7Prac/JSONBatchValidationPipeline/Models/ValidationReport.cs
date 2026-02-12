using System.Collections.Generic;

namespace Q07_JSONValidation.Models
{
    public class ValidationReport
    {
        public int TotalRecords { get; set; }
        public int ValidCount { get; set; }
        public int InvalidCount { get; set; }
        public List<ValidationError> Errors { get; set; } = new();
    }
}

