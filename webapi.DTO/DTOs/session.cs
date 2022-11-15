
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace  webapi.DTO{

public class Session
{
[BsonRepresentation(BsonType.ObjectId)] 
  public string _id { get; set; } 
    public string user { get; set; } 
    public string token { get; set; } 
     public string session { get; set; } 
    public string userAgent { get; set; } 
   public DateTime date {get;set;}
    
}

public class SessionbaseSettings
{
    public string ConnectionString { get; set; } 

    public string DatabaseName { get; set; } 

    public string SessionCollectionName { get; set; } 
}

}