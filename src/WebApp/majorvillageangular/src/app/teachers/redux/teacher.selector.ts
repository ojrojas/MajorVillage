import { createFeatureSelector } from "@ngrx/store";
import * as fromReducer from './teacher.reducer';

export const getTeacherState = createFeatureSelector<fromReducer.State>(fromReducer.teacherFeatureKey);
