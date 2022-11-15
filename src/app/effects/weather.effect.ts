import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { map, switchMap, mergeMap, catchError, debounceTime } from 'rxjs/operators';
import * as fromActions from '../actions/weatherAction';
import { WeatherService } from '../services/weather.sevice';

@Injectable()
export class WeatherEffects {

  constructor(
    private actions$: Actions,
    private weatherService: WeatherService
  ) { }

  

  GetRepByCoord$ = createEffect(() => this.actions$.pipe(
    ofType(fromActions.GetRepByCoord),
    map(action => action),
    mergeMap(rep =>
      this.weatherService.GetRepByCoord(rep.payload,rep.urlGet).pipe(
        map(res => fromActions.SetRepByCoord({payload: res}))
      )
    )
  ));
 
  GetRepByCity$ = createEffect(() => this.actions$.pipe(
    ofType(fromActions.GetRepByCity),
    map(action => action),
    mergeMap(rep =>
      this.weatherService.GetRepByCity(rep.payload,rep.urlGet).pipe(
        map(res => fromActions.SetRepByCity({payload: res}))
      )
    )
  ));
  CreateTable$ = createEffect(() => this.actions$.pipe(
    ofType(fromActions.createTable),
    map(action => action),
    mergeMap(rep =>
      this.weatherService.CreateTable(rep.payload).pipe(
        map(res => fromActions.createHeader({payload: res}))
      )
    )
  ));
}