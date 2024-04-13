namespace AnimalCrudApi.Dto
{
    public class UpdateAnimalRequest
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public int? Weight { get; set; }

    }
}
