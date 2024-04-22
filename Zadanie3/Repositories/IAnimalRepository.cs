using Zadanie3.Model;

namespace Zadanie3.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAnimals(string orderBy);
        int CreateAnimal(Animal animal);
        Animal GetAnimal(int idAnimal);
        int UpdateAnimal(int id, Animal animal);
        int DeleteAnimal(int idAnimal);
    }
}