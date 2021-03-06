using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services
{
    public class BooksService : IDisposable
    {
        private readonly IMongoCollection<Book> _booksCollection;
        private readonly ILogger<BooksService> _logger;

        public BooksService(
            MongoClient mongoClient,
            IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings,
            ILogger<BooksService> logger)
        {
            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(
                bookStoreDatabaseSettings.Value.BooksCollectionName);

            _logger = logger;
            log("Initialized a BooksService");
        }

        public async Task<List<Book>> GetAsync() =>
            await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<Book?> GetAsync(string id) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Book newBook) =>
            await _booksCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Book updatedBook) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);

        public void Dispose() =>
            log("Disposing of BooksService");

        private void log(string message) =>
            _logger.LogInformation(message);
    }
}
