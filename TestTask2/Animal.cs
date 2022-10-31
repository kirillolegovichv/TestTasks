namespace TestTask2;

public abstract class Animal
{
    public int MaxAge = 15;
    public string Breed { get; set; }
    public bool Wool = true;

    protected Animal(string breed)
    {   
        Breed = breed;
    }
}
