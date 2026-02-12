using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using Q07_JSONValidation.Models;

namespace Q07_JSONValidation.Services
{
    public class ValidationPipeline
    {
        private static readonly Regex EmailRegex =
            new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        private static readonly Regex PanRegex =
            new(@"^[A-Z]{5}[0-9]{4}[A-Z]$");

        public ValidationReport ValidateBatch(List<string> jsonPayloads)
        {
            var report = new ValidationReport
            {
                TotalRecords = jsonPayloads.Count
            };

            for (int i = 0; i < jsonPayloads.Count; i++)
            {
                try
                {
                    var app = JsonSerializer.Deserialize<CustomerApplication>(
                        jsonPayloads[i]);

                    var errors = Validate(app);

                    if (errors.Count == 0)
                    {
                        report.ValidCount++;
                    }
                    else
                    {
                        report.InvalidCount++;
                        foreach (var err in errors)
                        {
                            report.Errors.Add(
                                new ValidationError(i, err));
                        }
                    }
                }
                catch (Exception ex)
                {
                    report.InvalidCount++;
                    report.Errors.Add(
                        new ValidationError(i, $"Invalid JSON: {ex.Message}"));
                }
            }

            return report;
        }

        private List<string> Validate(CustomerApplication? app)
        {
            var errors = new List<string>();

            if (app == null)
            {
                errors.Add("Empty payload");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(app.Name))
                errors.Add("Name is mandatory");

            if (!EmailRegex.IsMatch(app.Email))
                errors.Add("Invalid email format");

            if (app.Age < 18 || app.Age > 60)
                errors.Add("Age must be between 18 and 60");

            if (!PanRegex.IsMatch(app.PAN))
                errors.Add("Invalid PAN format");

            return errors;
        }
    }
}

