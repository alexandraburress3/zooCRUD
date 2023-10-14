namespace zooCRUD.Models;

public class Lion : Animal
{
    public Lion(string name, int height, int weight)
    {
        Name = name;
        Height = height;
        Weight = weight;
        Species = Species.Lion;
        Happiness = 50;
    }
}