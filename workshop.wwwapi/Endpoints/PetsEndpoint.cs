using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModel;

namespace workshop.wwwapi.Endpoints
{
    public static class PetsEndpoint
    {
        public static void ConfigurePetEndpoint(this WebApplication app)
        {
            var pets = app.MapGroup("pets");

            pets.MapGet("/", GetPets);
            pets.MapPost("/", AddPet);
            pets.MapDelete("/{id}", DeletePet);
            pets.MapPut("/{id}", UpdatePet);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPets(IRepository repository)
        {
            var pets = repository.GetPets();
            return Results.Ok(pets);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddPet(IRepository repository, PetPost model)
        {
            Pet pet = new Pet()
            {
                Name = model.Name,
                Species = model.Species,
                Age = model.Age
            };
            repository.AddPet(pet);

            return Results.Created($"https://localhost:7010/pets/{pet.Id}", pet);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeletePet(IRepository repository, int id)
        {                        
            try
            {
                var model = repository.GetPet(id);
                if (repository.Delete(id)) return Results.Ok(new { When=DateTime.Now, Status="Deleted", Name=model.Name, Age=model.Age, Species=model.Species});
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdatePet(IRepository repository, int id,  PetPut model)
        {
            var target = repository.GetPet(id);
            if (target == null) return Results.NotFound();
            if (model.Name != null) target.Name = model.Name;
            if (model.Species != null) target.Species = model.Species;
            if (model.Age != null) target.Age = model.Age.Value;
            return Results.Ok(target);
        }

    }
}
