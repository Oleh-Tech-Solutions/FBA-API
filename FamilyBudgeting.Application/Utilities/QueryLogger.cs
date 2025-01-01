using Microsoft.Extensions.Logging;

namespace FamilyBudgeting.Infrastructure.Utilities
{
    public static class QueryLogger
    {
        public static void LogQuery(string query, object parameters, ILogger? logger = null)
        {
            // Serialize the parameters into a readable format
            var paramValues = parameters is not null
                ? string.Join(", ", parameters.GetType().GetProperties()
                    .Select(p => $"{p.Name}: {p.GetValue(parameters)}"))
                : "No parameters";

            if (logger is not null) 
            {
                logger.LogInformation("Executing Query: {Query} | Parameters: {Parameters}", query, paramValues);
            }
           
            Console.WriteLine($"Executing Query: {query} | Parameters: {paramValues}");
        }
    }
}
