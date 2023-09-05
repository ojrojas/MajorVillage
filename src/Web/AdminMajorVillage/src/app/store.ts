import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';
import { throttle } from 'lodash';
import StorageService from './core/services/storage.service';
import { rootReducer } from './combine.reducer';

const persistedState = StorageService.GetState();
export const store = configureStore({
	reducer: rootReducer, preloadedState: persistedState,
	middleware: (getDefaultMiddleware) => getDefaultMiddleware({ serializableCheck: false }),
});

store.subscribe(
	throttle(() => {
		if (process.env.NODE_ENV === "development") {
			console.info("state", store.getState());
			console.info("actions", store.dispatch);
		}
		StorageService.SaveState({
			...store.getState(),
		});
	}, 1000),
);

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
	ReturnType,
	RootState,
	unknown,
	Action<string>
>;
