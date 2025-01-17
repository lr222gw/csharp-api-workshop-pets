using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public static class PetsData
    {
        private static List<Pet> _pets { get; set; } = new List<Pet>();

        public static void Initialize()
        {
            _pets.Add(new Pet { Id = 1, Name = "Bella", Species = "Cat", Age = 1 });
            _pets.Add(new Pet { Id = 2, Name = "Red", Species = "Cat", Age = 1 });
            _pets.Add(new Pet { Id = 3, Name = "Lola", Species = "Dog", Age = 5 });
            _pets.Add(new Pet { Id = 4, Name = "Moby", Species = "Fish", Age = 4 });
        }
        public static Pet Get(int id)
        {
            return _pets.FirstOrDefault(p => p.Id == id)!;
        }
        public static Pet Add(Pet entity)
        {            
            entity.Id= _pets.Max(p => p.Id) + 1;
            _pets.Add(entity);
            return entity;

        }
        public static bool Remove(int id)
        {                        
            return _pets.RemoveAll(p => p.Id == id) > 0 ? true : false;
            
        }
        public static List<Pet> Pets { get { return _pets; } }
    }
}
