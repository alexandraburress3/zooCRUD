using zooCRUD.Models;

namespace zooCRUD;

public class Raccoon : Animal
{
    public Raccoon(string name, int height, int weight)
    {
        Name = name;
        Height = height;
        Weight = weight;
        Species = Species.Raccoon;
        Happiness = 80;
    }
}
