using Microsoft.AspNetCore.Mvc;
using Zadanie3.Model;
using Zadanie3.Services;

namespace Zadanie3.Controllers
{
    [Route("/api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _anaimalService;

        public AnimalsController(IAnimalService anaimalService) 
        {
            _anaimalService = anaimalService;
        }

        [HttpGet]
        public IActionResult GetAnimals(string orderBy = "Name")
        {
            var animals = _anaimalService.GetAnimals(orderBy);
            return Ok(animals);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = _anaimalService.GetAnimal(id);

            if (animal == null)
            {
                return NotFound("Animal not found");
            }

            return Ok(animal);
        }

        [HttpPost]
        public IActionResult CreateAnimal(Animal animal) 
        {
            var affectedCount = _anaimalService.CreateAnimal(animal);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateAnimal(int id, Animal animal)
        {
            var affectedCount = _anaimalService.UpdateAnimal(id, animal);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAnimal(int id) 
        {
            var affectedCount =  _anaimalService.DeleteAnimal(id);
            return NoContent();
        }
    }
}
