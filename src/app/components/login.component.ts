import { FormBuilder, Validators } from '@angular/forms'
import { Store } from '@ngrx/store';
import { Component,OnInit } from '@angular/core';    
import { Observable,BehaviorSubject } from 'rxjs';
import * as fromWeatherReducer from '../reducers/weather.reducer';
import * as fromActions from '../actions/weatherAction';
;
import { WeatherState } from '../reducers/app.states';
import { WeatherService } from '../services/weather.sevice';


import { cityReq,RootObjCity } from '../interfaces/cityWeather';
import { coordReq,RootObject,CurrentObject, Current } from '../interfaces/coordWeather';
@Component({
	selector: 'app-login',
	templateUrl: 'login.component.html'
})
export class LoginComponent implements OnInit{
  coord$: Observable<RootObject| undefined>;
  panelOpenState=false;
  //result = new BehaviorSubject([]);
	constructor( private store: Store<WeatherState>,public wh:WeatherService) {
    this.coord$ = store.select(fromWeatherReducer.GetRepCoord);
    
	}
    getData(data:Current|undefined):CurrentObject[]|undefined{
return data?[new CurrentObject(data)]:undefined;
    }
    ngOnInit() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition((position)=>{
              const coord:coordReq={}
              const city:cityReq={}
              coord.lon = position.coords.longitude;
              coord.lat = position.coords.latitude;
             
              this.store.dispatch(fromActions.GetRepByCoord({payload: coord,urlGet:"\\Weather\\fetUserRep"}));
              
          }
            );
           
        } else {
           console.log("No support for geolocation")
        }
      
        
       
             }

	xxx() {
	
        
	 }
     
	
	
}	