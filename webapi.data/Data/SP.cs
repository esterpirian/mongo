using System;
using webapi.DTO;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace webapi.data
{
   public class SPService
{
    private readonly IMongoCollection<MeetA> _spCollection;

    public SPService(
        IOptions<SPDatabaseSettings> spDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            spDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            spDatabaseSettings.Value.DatabaseName);

        _spCollection = mongoDatabase.GetCollection<MeetA>(
            spDatabaseSettings.Value.SPCollectionName);
    }

  
  
        public async Task<List<Meet>>  UpdateFilterAsync() {
          //var filter = Builders<Meet>.Filter.Eq(x => x.g, city));
// // // ;
//             var update = Builders<Meet>.Update.Set(x => x.inMeeating[0].city, "Bob");

//             await _meetsCollection.UpdateManyAsync(filter, update);
//var filter = BsonDocument.Parse(" getMeets() ");
// var result = collection.Find(filter).FirstOrDefault(); 
// var cmd = new JsonCommand<Meet>();
// var result = _spCollection.a(cmd);
BsonJavaScript reduce = @"
            db.loadServerScripts();";
            BsonJavaScript reduce1 = @"
            db.system.js.find()
            db.loadServerScripts();
            getMeets()";
            FindOptions MyFindOptions = new FindOptions();
MyFindOptions.Comment = "db.system.js.find() db.loadServerScripts();getMeets()";
//List<Meet>
// var cursor = _spCollection.Find<MeetA>(new BsonDocument(), MyFindOptions).FirstOrDefault();
// Console.Write(cursor);
 new JsonCommand<BsonDocument>($"{{ eval: \"getMeets()\" }}");
 //var cursor = _spCollection.Find<MeetA>(new JsonCommand<BsonDocument>($"{{ eval: \"getMeets()\" }}")).FirstOrDefault();
//Console.Write(cursor);
            return new List<Meet>();
            //wait _spCollection.Ru<Meet>(reduce1).ToListAsync();
            //return a;
        }

}
}

