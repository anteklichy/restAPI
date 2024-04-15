namespace WebApplication1.Animal;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    bool CreateAnimal(CreateAnimalDTO dto);
    bool UpdateAnimal(int idAnimal, UpdateAnimalDTO dto);
    bool DeleteAnimal(int idAnimal);
}

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;
    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return _animalRepository.FetchAllAnimals(orderBy);
    }

    public bool CreateAnimal(CreateAnimalDTO dto)
    {
        return _animalRepository.CreateAnimal(dto.Name);
    }

    public bool UpdateAnimal(int idAnimal, UpdateAnimalDTO dto)
    {
        return _animalRepository.UpdateAnimal(idAnimal, dto.Name);
    }

    public bool DeleteAnimal(int idAnimal)
    {
        return _animalRepository.DeleteAnimal(idAnimal);
    }
}