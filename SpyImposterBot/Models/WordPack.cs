internal class WordPack
{
    public long Id { get; set; }
    public long? UserId { get; set; }
    public string Name { get; set; } = "";
    public bool IsPublic { get; set; }
    public bool HasImage { get; set; }
    public string? SpyImageFileId { get; set; }
}
