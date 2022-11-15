import { createAction, props } from '@ngrx/store';
import { Login } from '../models/article';

export const SineIn = createAction('[Login] Sign In', props<{ payload:Login}>());
export const GetByIdSuccessAction = createAction('[Login] GetByIdSuccessAction', props<{ payload: Login[]}>());
export const GetByIdErrorAction = createAction('[Login] GetByIdErrorAction');
export const SetIsLogin = createAction('[Login] SetIsLogin', props<{ payload: boolean}>());
export const KeepAlive = createAction('[Login] Keep Alive');
