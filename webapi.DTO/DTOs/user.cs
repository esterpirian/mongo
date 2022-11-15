
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace  webapi.DTO{

public class User
{
[BsonRepresentation(BsonType.ObjectId)] 
  public string _id { get; set; } 
    public string user { get; set; } 
    public string token { get; set; } 
    
}

public class UserbaseSettings
{
    public string ConnectionString { get; set; } 

    public string DatabaseName { get; set; } 

    public string UserCollectionName { get; set; } 
}

}