using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Pet>> GetPets();
        Task<Pet> GetPet(int id);
        Task<bool> Delete(int id);
        Task<Pet> AddPet(Pet pet);
    }
}
