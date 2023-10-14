namespace zooCRUD.Models;

public class Animal
{
    /// <summary>
    /// What type of animal this is
    /// </summary>
    public Species Species { get; set; }
    /// <summary>
    /// Animal's Name and identifier
    /// </summary>
    public string Name { get; set; } = "defaultName";
    /// <summary>
    /// Animal's height in cm
    /// </summary>
    public int Height { get; set; }
    /// <summary>
    /// Animal's weight in kg
    /// </summary>
    public int Weight { get; set; }
    /// <summary>
    /// How content the animal is currently
    /// </summary>
    public int Happiness { get; set; } = 15;

    public void Eat()
    {
        Happiness += 1;
    }

    public void Sleep()
    {
        Happiness += 5;
    }
}