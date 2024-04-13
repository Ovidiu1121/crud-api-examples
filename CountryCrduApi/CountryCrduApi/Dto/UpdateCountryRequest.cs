namespace CountryCrduApi.Dto
{
    public class UpdateCountryRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Capital { get; set; }
        public int? Population { get; set; }

    }
}
