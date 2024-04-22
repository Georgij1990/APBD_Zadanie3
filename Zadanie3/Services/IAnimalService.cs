using Zadanie3.Model;

namespace Zadanie3.Services
{
    public interface IAnimalService
    {
        IEnumerable<Animal> GetAnimals(string orderBy);
        Animal? GetAnimal(int id);
        int CreateAnimal(Animal animal);
        int UpdateAnimal(int id, Animal animal);
        int DeleteAnimal(int id);
    }
}
