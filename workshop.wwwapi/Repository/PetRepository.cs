using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class PetRepository  : IRepository
    {
        private DataContext _db;
        public PetRepository(DataContext db)
        {
            this._db = db;
            
        }
        public Pet AddPet(Pet entity)
        {            
            _db.pets.Add(entity);
            _db.SaveChanges();
            return entity;
            
        }

        public bool Delete(int id)
        {

            throw new System.NotImplementedException();
            
        }

        public Pet GetPet(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Pet> GetPets()
        {
            return _db.pets.ToList();      
        }
    }
}
