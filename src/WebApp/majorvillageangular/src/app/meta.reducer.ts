import { ActionReducer, MetaReducer, INIT, UPDATE } from '@ngrx/store';
import { environment } from 'src/environments/environment';
import { AppState } from './app.reducer';

export function storageMetareducers(reducer: ActionReducer<AppState>): ActionReducer<AppState> {
    return (state, action) => {
        try {
            if (environment.production === false) {
                console.log('state', state);
                console.log('action', action);
            }
            if (action.type === INIT || action.type === UPDATE) {
                const stateSaved = localStorage.getItem('_storageMajorVillage_');
                if (stateSaved) {
                    try {
                        return JSON.parse(stateSaved);
                    } catch (error) {
                        localStorage.removeItem('_storageMajorVillage_');
                    }
                }
            }
            let newState = reducer(state, action);
            localStorage.setItem("_storageMajorVillage_", JSON.stringify(newState));
            return newState;
        } catch (error) {
            console.error("Error => ", error);
            localStorage.removeItem('_storageMajorVillage_')
        }
    };
}

export const metaReducers: MetaReducer<any>[] = [storageMetareducers];