using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Animal;

[Route("/api/animal")]
[ApiController]
public class AnimalController : ControllerBase
{
    private IAnimalService _animalService;
    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
    
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAnimals([FromQuery] string orderBy)
    {
        var animals = _animalService.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult CreateAnimal([FromBody] CreateAnimalDTO dto)
    {
        var success = _animalService.CreateAnimal(dto);
        return success ? Created() : Conflict();
    }
    
    [HttpPut("{idAnimal}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult UpdateAnimal(int idAnimal, [FromBody] UpdateAnimalDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var success = _animalService.UpdateAnimal(idAnimal, dto);
        return success ? Ok() : BadRequest();
    }

    [HttpDelete("{idAnimal}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteAnimal(int idAnimal)
    {
        var success = _animalService.DeleteAnimal(idAnimal);
        return success ? Ok() : NotFound();
    }
}
