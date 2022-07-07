import { createReducer, on } from '@ngrx/store';
import * as fromActions from './teacher.action';

export const teacherFeatureKey = 'teacher';

export interface State {
    isloading:boolean,
    error: any
}

const inistalState: State = {
    isloading:false,
    error: null
}

export const reducer = createReducer(
    inistalState, 
    on(fromActions.getAllTeachers, (state) => ({
        ...state,
        isloading:true,
    }))
)