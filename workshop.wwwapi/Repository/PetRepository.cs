using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class PetRepository  : IRepository
    {
        private DataContext _db;

        public PetRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<Pet> AddPet(Pet entity)
        {       
            await _db.Pets.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
            
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
            
            
        }

        public Task<Pet> GetPet(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Pet>> GetPets()
        {
            return await _db.Pets.ToListAsync();
        }
    }
}
