using System;
using webapi.DTO;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
namespace webapi.data
{
   public class MeetsService
{
    private readonly IMongoCollection<Meet> _meetsCollection;

    public MeetsService(
        IOptions<MeetStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _meetsCollection = mongoDatabase.GetCollection<Meet>(
            bookStoreDatabaseSettings.Value.MeetsCollectionName);
    }

    public async Task<List<Meet>> GetAsync() =>
        await _meetsCollection.Find(_ => true).ToListAsync();

    public async Task<Meet> GetAsync(double id) =>
        await _meetsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Meet newMeet) =>
        await _meetsCollection.InsertOneAsync(newMeet);

    public async Task UpdateAsync(double id, Meet updatedBook) =>
        await _meetsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task  RemoveAsync(double id) =>
        await _meetsCollection.DeleteOneAsync(x => x.Id == id);
        public async Task  UpdateFilterAsync(string city) {
          var filter = Builders<Meet>.Filter.ElemMatch(x => x.inMeeating, Builders<MeetIn>.Filter.Eq(x => x.city, city));
// // ;
            var update = Builders<Meet>.Update.Set(x => x.inMeeating[0].city, "Bob");

            await _meetsCollection.UpdateManyAsync(filter, update);
// var cmd = new JsonCommand<BsonDocument>("{ eval: \"test_function(2)\" }");
// var result = db.RunCommand(cmd);
            // return await _meetsCollection.Find(filter).ToListAsync();
            //return a;
        }

}
}

