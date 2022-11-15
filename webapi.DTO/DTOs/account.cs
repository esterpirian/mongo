
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace  webapi.DTO{


public class UserDetail
{
[BsonRepresentation(BsonType.ObjectId)] 
  public string _id { get; set; } 
    public string user { get; set; } 
    public string currency { get; set; } 
    public int idNumber { get; set; } 
    public int account { get; set; } 
  
}
public class AccountbaseSettings
{
    public string ConnectionString { get; set; } 

    public string DatabaseName { get; set; } 

    public string AccountCollectionName { get; set; } 
}

}