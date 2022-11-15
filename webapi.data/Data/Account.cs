using System;
using webapi.DTO;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
namespace webapi.data
{
   public class AccountService
{
    private readonly IMongoCollection<UserDetail> _accountCollection;

    public AccountService(
        IOptions<AccountbaseSettings> accountDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            accountDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            accountDatabaseSettings.Value.DatabaseName);

        _accountCollection = mongoDatabase.GetCollection<UserDetail>(
            accountDatabaseSettings.Value.AccountCollectionName);
    }

   

    public async Task<UserDetail> GetAsync(string user) =>
        await _accountCollection.Find(x => x.user == user).FirstOrDefaultAsync();

    public async Task CreateAsync(UserDetail newUser) =>
        await _accountCollection.InsertOneAsync(newUser);

   
}
}

