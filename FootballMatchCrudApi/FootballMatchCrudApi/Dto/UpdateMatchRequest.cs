namespace FootballMatchCrudApi.Dto
{
    public class UpdateMatchRequest
    {
        public int? Id { get; set; }    
        public string? Stadium { get; set; }
        public string? Score { get; set; }
        public string? Country { get; set; }

    }
}
