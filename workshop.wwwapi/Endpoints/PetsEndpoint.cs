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
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPets(IRepository repository)
        {
            var pets = repository.GetPets();
            return Results.Ok(pets);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddPet(IRepository repository, PetPost model)
        {
            Pet pet = new Pet()
            {
                Name = model.Name,
                Species = model.Species,
                Age = model.Age
            };
            repository.AddPet(pet);

            return Results.Ok(pet);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeletePet(IRepository repository, int id)
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
    }
}
