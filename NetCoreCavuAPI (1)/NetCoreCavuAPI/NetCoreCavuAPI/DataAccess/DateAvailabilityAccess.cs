using CavuWebApp.Models;

namespace CavuWebApp.DataAccess
{
    /// <summary>
    /// Access to get date availability from a JSON file 
    /// </summary>
    public class DateAvailabilityAccess
    {

        private List<DateAvailabilityRecord> dateAvailabilityRecords = new List<DateAvailabilityRecord>();
        private readonly string projectDirectory;

        /// <summary>
        /// Gets all dates information currently set to get next months dates 
        /// </summary>
        public DateAvailabilityAccess()
        {

            // Get the project directory to build up the file paths
            projectDirectory = Directory.GetCurrentDirectory();
            projectDirectory = projectDirectory + "\\DateAvailabilityJSON\\" + "DateAvailability.json";

            var jsonDateAvailability = File.ReadAllLines(@projectDirectory);
            
            string flattenedStringOfDateAvailabityRules = string.Concat(jsonDateAvailability);

            dateAvailabilityRecords = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DateAvailabilityRecord>>(flattenedStringOfDateAvailabityRules, new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
            });

        }

        /// <summary>
        /// Gets the dates based on the From and To
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        public List<DateAvailabilityRecord> GetJsonDateDataByRange(DateTime From, DateTime To)
        {
            var datesInRange = dateAvailabilityRecords.Where(x => x.Date >= From && x.Date <= To && x.IsSpaceFull != true).ToList();

            return datesInRange;
        }

    }
}
