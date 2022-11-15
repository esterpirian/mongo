import { createFeatureSelector, createSelector, createReducer, on, Action } from '@ngrx/store';
import * as fromActions from '../actions/weatherAction';
import { WeatherState } from './app.states';

export const initialState: WeatherState = {coordReq:{},cityReq:{},city:{},coord:{},url:"",data:{},header:{}};

// Creating reducer
const _weatherReducer = createReducer(
  initialState,
  on(fromActions.SineIn, (state) => ({})),
  on(fromActions.GetRepByCoord, (state, {payload,urlGet}) => ({coordReq: payload,url:urlGet})),
  on(fromActions.GetRepByCity, (state, {payload,urlGet}) => ({ cityReq:payload,url:urlGet})),
  on(fromActions.SetRepByCity, (state, {payload}) => ({city:payload})),
  on(fromActions.SetRepByCoord, (state, {payload}) => ({coord:payload})),
  on(fromActions.createTable, (state, {payload}) => ({data:payload})),
  on(fromActions.createHeader, (state, {payload}) => ({header:payload}))
);

export function weatherReducer(state: any, action: Action) {
  return _weatherReducer(state, action);
}

// Creating selectors
export const getWeatherState = createFeatureSelector<WeatherState>('weatherState');

export const GetRepCoord = createSelector(
    getWeatherState, 
    (state: WeatherState) => state.coord 
);
export const GetCityRep = createSelector(
    getWeatherState, 
    (state: WeatherState) => state.city
  );
  export const GetHeaders = createSelector(
    getWeatherState, 
    (state: WeatherState) => state.header
  );
