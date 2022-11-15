import { Injectable } from '@angular/core';
import { Observable,of } from 'rxjs';
import{postService} from './postService'
import { cityReq,RootObjCity, Factory} from '../interfaces/cityWeather';
import { coordReq,RootObject,Header,Table } from '../interfaces/coordWeather';

@Injectable()
export class WeatherService {
    constructor(private postService: postService) { }

    GetRepByCoord(data:coordReq,url:string): Observable<RootObject> {
       
        return this.postService.doPost<RootObject>(url,data);
    }    
    GetRepByCity(data:cityReq,url:string): Observable<RootObjCity> {
       
        return this.postService.doPost<RootObjCity>(url,data);
    }  
    CreateTable(data:Table): Observable<Header> {
        var myData:Header ={columns:{}};
         Object.keys(data.key).forEach((val) => myData.columns=myData.columns && {[val]:{'title':val}});
    //   return  
       return  (of(myData)) as Observable<Header>
    } 
    CreateHeader(data:any): Header {
        var myData:Header ={columns:{}};
         Object.keys(data).forEach((val) => myData.columns[val]= {'title':val});
    //   return  
       return  myData;
    }   
   
        getData(data:any|undefined):any[]|undefined{
      
  var d:any[]=[];
data?.forEach((val:any) => d.push(val));
return data?d:undefined;
      
          

    }
    
}