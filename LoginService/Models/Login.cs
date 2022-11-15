using System;
using System.Collections.Generic;

namespace  data.Models{

public class UserLogin
{
    

    public string userName { get; set; } 
    public string passwprd { get; set; } 
    

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
