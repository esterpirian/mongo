import { ActionReducerMap } from '@ngrx/store';
import { AppState } from './app.states';

import * as fromWeatherReducer from './weather.reducer';
export const reducers: ActionReducerMap<AppState> = {
 
  weatherState:fromWeatherReducer.weatherReducer
};
 