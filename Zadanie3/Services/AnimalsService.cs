using Zadanie3.Model;
using Zadanie3.Repositories;

namespace Zadanie3.Services
{
    public class AnimalsService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalsService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public int CreateAnimal(Animal animal)
        {
            return _animalRepository.CreateAnimal(animal); ;
        }

        public Animal? GetAnimal(int id)
        {
            return _animalRepository.GetAnimal(id);
        }

        public IEnumerable<Animal> GetAnimals(string orderBy)
        {
            return _animalRepository.GetAnimals(orderBy);
        }

        public int UpdateAnimal(int id, Animal animal)
        {
            return _animalRepository.UpdateAnimal(id, animal);
        }

        public int DeleteAnimal(int id)
        {
            return _animalRepository.DeleteAnimal(id);
        }
    }
}
