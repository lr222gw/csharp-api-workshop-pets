using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public static class PetsData
    {
        public static List<Pet> Pets { get; set; } = new List<Pet>();

        public static void Initialize()
        {
            Pets.Add(new Pet { Id = 1, Name = "Bella", Species = "Cat", Age = 1 });
            Pets.Add(new Pet { Id = 2, Name = "Red", Species = "Cat", Age = 1 });
            Pets.Add(new Pet { Id = 3, Name = "Lola", Species = "Dog", Age = 5 });
            Pets.Add(new Pet { Id = 4, Name = "Moby", Species = "Fish", Age = 4 });
        }
    }
}
