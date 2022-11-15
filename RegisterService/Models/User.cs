using System;
using System.Collections.Generic;

namespace  data.Models{

public class UserRegister
{
    

    public string userName { get; set; } 
    public string passwprd { get; set; } 
    public string Id { get; set; } 
    public string Account { get; set; } 
     public string currency { get; set; } 

}
public class SecurityToken
    {
        public string auth_token { get; set; }
    }
public class AppSettings
    {
        public string Secret { get; set; }
    }
}
public enum IsRegister{
   Success=0,
    Exist=1,
    Error=2

}