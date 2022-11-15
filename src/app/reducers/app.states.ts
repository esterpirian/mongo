
import { cityReq,RootObjCity } from '../interfaces/cityWeather';
import { coordReq,RootObject,Header,Table } from '../interfaces/coordWeather';
export interface AppState {
	
	weatherState:WeatherState
	
}


export interface WeatherState {
	cityReq?:cityReq;
	coordReq?:coordReq;
	city?:RootObjCity;
	coord?:RootObject;
	url?:string;
	data?:Table;
	header?:Header;
}