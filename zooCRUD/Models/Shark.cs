using zooCRUD.Models;

namespace zooCRUD;

public class Shark : Animal
{
    public Shark(string name, int height, int weight)
    {
        Name = name;
        Height = height;
        Weight = weight;
        Species = Species.Shark;
        Happiness = 35;
    }
}
