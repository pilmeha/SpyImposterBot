namespace SpyImposterBot.Models
{
    internal class GameSession
    {
        public long Id { get; set; }
        public long CreatedBy { get; set; }
        public long PackId { get; set; }
        public string GameMode { get; set; } = "";
        public string PlayersData { get; set; } = "";
        public int CurrentPlayerIndex { get; set; }
        public string Status { get; set; } = "";
    }
}
