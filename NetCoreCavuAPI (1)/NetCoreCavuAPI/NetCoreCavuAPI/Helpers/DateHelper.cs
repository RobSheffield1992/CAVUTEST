namespace CavuWebApp.Helpers
{
    /// <summary>
    /// Performs operations on dates
    /// </summary>
    public class DateHelper
    {
        /// <summary>
        /// Return list of dates between the two requested dates
        /// </summary>
        /// <returns></returns>
        public static List<DateTime> GetRangeOfDates(DateTime From, DateTime To)
        {
            // Return the available date range
            return Enumerable.Range(0, 1 + To.Subtract(From).Days)
           .Select(offset => From.AddDays(offset))
           .ToList();

        }

    }
}

