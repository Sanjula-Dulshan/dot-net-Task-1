using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Greet(string fullname, DateTime dateOfBirth)

        {
            var age = CalculateAge(dateOfBirth);
            return Ok($"Hello, my name is {fullname} and I am {age} years old");
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            // Check if the birthday has occurred for the current year
            // If the birth date is later than today minus the calculated age
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;

        }

        
    }
}
