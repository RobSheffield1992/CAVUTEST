namespace CavuWebApp.Models
{
    /// <summary>
    /// Class to store date availability 
    /// </summary>
    public class DateAvailabilityRecord
    {
        public DateTime Date;

        public int AvailableSpaces { get; set; }

        public bool IsSpaceFull { get; set; }
    }
}
