using Microsoft.AspNetCore.Mvc;

namespace petNameGenerator.Controllers
{
    [ApiController]
    [Route("api/petGenerator")]
    public class petGenerator : Controller
    {
        private string[] dogNames = 
        {
            "Buddy", "Max", "Charlie", "haru", "Letchon" 
        };
        private string[] catNames = 
        { 
            "Tilafi", "kitty", "Meowmi", "void", "duffy" 
        };
        private string[] birdNames = 
        { 
            "chick", "kippu", "chirpy", "sks", "Paro"
        };

        public class pet
        {
            public string animalType { get; set; }
            public bool? twoPart {  get; set; }
        }

        [HttpGet("generate")]
        public IActionResult Index()
        {
            Random rnd = new Random();
            int index = rnd.Next(dogNames.Length);
            string generateName = dogNames[index];
            return Ok(new { generateName });
        }

        [HttpPost]
        public IActionResult Post(string animalType, bool twoPart = false)
        {
            string[] selectedType;

            if (animalType == "dog")
            {
                selectedType = dogNames;
            }
            else if (animalType == "cat")
            {
                selectedType = catNames;
            }
            else if (animalType == "bird")
            {
                selectedType = birdNames;
            }
            else
            {
                return BadRequest(new { error = "Invalid animal type. Allowed values: dog, cat, bird." });
            }

            Random rnd = new Random();
            string name = selectedType[rnd.Next(selectedType.Length)];

            if (twoPart)
            {
                string secondName = selectedType[rnd.Next(selectedType.Length)];
                name += secondName;
            }

            return Ok(new { name });
        }
    }
}
