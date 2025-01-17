namespace workshop.wwwapi.ViewModel
{
    public class PetResponse
    {
        public DateTime When { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Deleted";
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }
    }
}
