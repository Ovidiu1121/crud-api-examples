namespace CarCrudApi.Dto
{
    public class UpdateCarRequest
    {
        public int? Id { get; set; }
        public string? Brand { get; set; }
        public int? Price { get; set; }
        public int? Horse_power { get; set; }
        public int? Fabrication_year { get; set; }

    }
}
