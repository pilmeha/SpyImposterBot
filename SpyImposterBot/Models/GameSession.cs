using SpyImposterBot.Enums;

internal class GameSession
{
    public long Id { get; set; }
    public long CreatedBy { get; set; }
    public long PackId { get; set; }
    //public GameMode GameMode { get; set; }
    public string PlayersData { get; set; } = "";
    public int CurrentPlayerIndex { get; set; }
    public GameStatus Status { get; set; }
    public string Word { get; set; }
    public string? ImageFileId { get; set; }
    public bool HasImages { get; set; }
}
