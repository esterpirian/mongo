using System;
using webapi.DTO;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
namespace webapi.data
{
   public class SessionService
{
    private readonly IMongoCollection<webapi.DTO.Session> _sessionCollection;

    public SessionService(
        IOptions<SessionbaseSettings> sessionDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            sessionDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            sessionDatabaseSettings.Value.DatabaseName);

        _sessionCollection = mongoDatabase.GetCollection<webapi.DTO.Session>(
            sessionDatabaseSettings.Value.SessionCollectionName);
    }

   

    public async Task<Session> GetAsync(string session) =>
        await _sessionCollection.Find(x => x.session == session).FirstOrDefaultAsync();

    public async Task CreateAsync(Session newUser) =>
        await _sessionCollection.InsertOneAsync(newUser);

   
}
}

