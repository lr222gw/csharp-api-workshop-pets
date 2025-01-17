using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class PetRepository : IRepository
    {
        public Pet AddPet(Pet entity)
        {
            
            return PetsData.Add(entity);
            
        }

        public bool Delete(int id)
        {

            return PetsData.Remove(id);
            
        }

        public Pet GetPet(int id)
        {            
            return PetsData.Get(id);
        }

        public IEnumerable<Pet> GetPets()
        {
            return PetsData.Pets;            
        }
    }
}
