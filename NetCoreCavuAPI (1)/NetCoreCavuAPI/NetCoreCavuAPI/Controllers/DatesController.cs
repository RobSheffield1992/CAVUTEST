using CavuWebApp.DataAccess;
using CavuWebApp.Helpers;
using CavuWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreCavuAPI.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class DatesController : Controller
    {
        private readonly DateAvailabilityAccess dateAvailabilityAccess = new DateAvailabilityAccess();
        
        
        /// <summary>
        /// Get available parking dates
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAvailableDates(DateTime From, DateTime To)
        {             
            // Get JSON for each date showing whether each date is available or not 
            var dateAvailability = dateAvailabilityAccess.GetJsonDateDataByRange(From, To);

            // Serialise back to JSON
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dateAvailability);
            
            // Return the JSON list
            return Json(new { jsonData });
        }

    }
}