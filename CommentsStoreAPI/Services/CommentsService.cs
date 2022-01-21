using CommentsStoreAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CommentsStoreAPI.Services
{
    public class CommentsService
    {
        private readonly IMongoCollection<Commentary> _commentsCollection;

        public CommentsService(IOptions<CommentStoreDBSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var mongoDB = mongoClient.GetDatabase(options.Value.DatabaseName);

            _commentsCollection = mongoDB.GetCollection<Commentary>(options.Value.CommentCollectionName);
        }
        public async Task<List<Commentary>> GetAsync() =>
            await _commentsCollection.Find(_=>true).ToListAsync();

        public async Task<Commentary> GetAsync(string id) => 
            await _commentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Commentary newComment) => 
            await _commentsCollection.InsertOneAsync(newComment);

        public async Task UpdateAsync(string id, Commentary updatedComment) =>
            await _commentsCollection.ReplaceOneAsync(x => x.Id == id, updatedComment);

        public async Task DeleteAsync(string id) =>
            await _commentsCollection.DeleteOneAsync(x => x.Id == id);



    }

}
