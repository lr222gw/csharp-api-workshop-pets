using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PetsEndpoint
    {
        public static void ConfigurePetEndpoint(this WebApplication app)
        {
            var pets = app.MapGroup("pets");

            pets.MapGet("/", GetPets);
        }

        public static async Task<IResult> GetPets(IRepository repository)
        {
            var pets = repository.GetPets();
            return Results.Ok(pets);
        }
    }
}
