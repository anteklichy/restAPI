using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Animal;

public class CreateAnimalDTO
{
    [Required]
    public string Name { get; set; }
}

public class UpdateAnimalDTO
{
    [Required]
    public string Name { get; set; }
}