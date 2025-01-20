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

        public async Task<bool> Delete(int id)
        {
            var target = await _db.Pets.FindAsync(id);
            _db.Pets.Remove(target);
            await _db.SaveChangesAsync();
            return true;


        }

        public async Task<Pet> GetPet(int id)
        {
            return await _db.Pets.FindAsync(id);
        }

        public async Task<IEnumerable<Pet>> GetPets()
        {
            return await _db.Pets.ToListAsync();
        }
    }
}
