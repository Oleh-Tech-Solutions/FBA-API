using Microsoft.Extensions.Logging;

namespace FamilyBudgeting.Infrastructure.Utilities
{
    public static class QueryLogger
    {
        public static void LogQuery(string query, object? parameters, ILogger? logger = null)
        {
            string paramValues;

            if (parameters is null)
            {
                paramValues = "No parameters";
            }
            else if (parameters.GetType().IsPrimitive || parameters is string || parameters is decimal)
            {
                // Handle primitive types, string, and decimal
                paramValues = parameters.ToString() ?? "Null";
            }
            else
            {
                // Handle complex objects by serializing their properties
                paramValues = string.Join(", ", parameters.GetType().GetProperties()
                    .Select(p => $"{p.Name}: {p.GetValue(parameters)}"));
            }

            // Log to the logger if provided
            if (logger is not null)
            {
                logger.LogInformation("Executing Query: {Query} | Parameters: {Parameters}", query, paramValues);
            }

            // Log to the console
            Console.WriteLine($"Executing Query: {query} | Parameters: {paramValues}");
        }
    }
}
