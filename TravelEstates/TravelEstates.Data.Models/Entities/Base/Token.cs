namespace TravelEstates.Data.Models.Entities.Base
{
    public class Token
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public DateTime ValidUntil { get; set; }

        public bool IsUsed { get; set; }

        public string Value { get; set; } = null!;

        public string Type { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
