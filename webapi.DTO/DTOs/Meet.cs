
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace  webapi.DTO{
public class Meet
{
    [BsonElement("_id")]
    public double Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } 
     public List<MeetIn> inMeeating { get; set; }
    
}
public class MeetIn
{
       public string addess { get; set; }

       public string city { get; set; } 
       public string desc { get; set; } 
       public DateTime startDate{ get; set; } 
       public DateTime endDate{ get; set; } 
    
}
public class MeetRequest
{
       public string id { get; set; }

       public string name { get; set; } 
      
    
}
public class MeetStoreDatabaseSettings
{
    public string ConnectionString { get; set; } 

    public string DatabaseName { get; set; } 

    public string MeetsCollectionName { get; set; } 
}
public class City
{
    [BsonElement("id")]
    public double Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } 
       
}
}