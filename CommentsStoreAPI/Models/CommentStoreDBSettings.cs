namespace CommentsStoreAPI.Models
{
    public class CommentStoreDBSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CommentCollectionName { get; set; } = null!;
    }
}
