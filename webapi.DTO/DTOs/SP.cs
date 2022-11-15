
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace  webapi.DTO{

public class MeetA
{
    public string _id { get; set; }

       public string name { get; set; } 
     public List<MeetIn> inMeeating { get; set; }
    
}
public class SPDatabaseSettings
{
    public string ConnectionString { get; set; } 

    public string DatabaseName { get; set; } 

    public string SPCollectionName { get; set; } 
}

}