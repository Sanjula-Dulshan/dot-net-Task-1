using Microsoft.AspNetCore.Mvc;

namespace Task_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult Greet(string fullname, DateTime dateOfBirth)

        {
            var age = CalculateAge(dateOfBirth);
            return Ok($"Hello, my name is {fullname} and I am {age} years old");
        }

        [HttpGet("name")]
        public ActionResult GetNames(string name)

        {
            var fullNames = new List<string> { "Sanjula Dulshan", "Ravindu Yasith","Piumika Saranga" };
            var matchingNames = fullNames.Where(n=>n.Contains(name)).ToList();
            return Ok(matchingNames);
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
