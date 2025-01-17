using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class PetRepository : IRepository
    {
        public Pet AddPet(Pet entity)
        {
            int id = PetsData.Pets.Max(p => p.Id) + 1;
            PetsData.Pets.Add(entity);
            return entity;
        }

        public Pet DeletePet(int id)
        {
            var result = PetsData.Pets.FirstOrDefault(p => p.Id == id);
            PetsData.Pets.RemoveAll(p => p.Id==id);
            return result;
        }

        public Pet GetPet(int id)
        {
            var result = PetsData.Pets.FirstOrDefault(p => p.Id == id);
            return result;
        }

        public IEnumerable<Pet> GetPets()
        {
            var results = PetsData.Pets;
            return results;
        }
    }
}
