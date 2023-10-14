using zooCRUD.Models;

namespace zooCRUD.Interfaces;

public interface IZooRepository
{
    string PostAnimal(string name, Species species, int height, int weight);
    Animal GetAnimal(string name, Species species);
    string UpdateAnimal(string name, Species species, int height, int weight);
    string DeleteAnimal(string name, Species species);
    List<Animal> GetAllAnimals();
}