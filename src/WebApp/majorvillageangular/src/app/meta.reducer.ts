import { ActionReducer, MetaReducer } from '@ngrx/store';
import { merge } from 'lodash'

export function storageMetareducers(reducer: ActionReducer<any>): ActionReducer<any> {
    return (state, action) => {
        try {
            console.log('state', state);
            console.log('action', action);
            const newState =  reducer(state, action);
            const stateSaved =  JSON.parse(localStorage.getItem('_storageMajorVillage_') ?? '{}');
            console.log("stateSaved ==> ", stateSaved);
            merge(newState, stateSaved);
            localStorage.setItem("_storageMajorVillage_", JSON.stringify(newState));
            return newState;
        } catch (error) {
            console.error("Error => ", error);
        }
    };
}

export const metaReducers: MetaReducer<any>[] = [storageMetareducers];