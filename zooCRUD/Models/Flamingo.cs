using zooCRUD.Models;

namespace zooCRUD;

public class Flamingo : Animal
{
    public Flamingo(string name, int height, int weight)
    {
        Name = name;
        Height = height;
        Weight = weight;
        Species = Species.Flamingo;
        Happiness = 65;
    }
}
