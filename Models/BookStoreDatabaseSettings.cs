namespace BookStoreApi.Models
{
    public class BookStoreDatabaseSettings
    {
        public const string SectionName = "BookStoreDatabase";

        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string BooksCollectionName { get; set; } = null!;
    }
}
