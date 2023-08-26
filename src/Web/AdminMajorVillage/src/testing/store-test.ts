import { configureStore, ThunkAction, Action, PreloadedState } from '@reduxjs/toolkit';
import { throttle } from 'lodash';
import { rootReducer } from '../app/combine.reducer';
import StorageService from '../app/core/services/storage.service';

export const setupStore = (persistedState?: PreloadedState<RootState>) => 
	 configureStore({
	reducer: rootReducer
	, preloadedState: persistedState,
	middleware: (getDefaultMiddleware) => getDefaultMiddleware({ serializableCheck: false }),
});

setupStore().subscribe(
	throttle(() => {
		if (process.env.NODE_ENV === "development") {
			console.info("state", setupStore().getState());
			console.info("actions", setupStore().dispatch);
		}
		StorageService.SaveState({
			...setupStore().getState(),
		});
	}, 1000),
);

export type RootState = ReturnType<typeof rootReducer>;
export type AppStore = ReturnType<typeof setupStore>
export type AppDispatch = AppStore['dispatch'];
export type AppThunk<ReturnType = void> = ThunkAction<
	ReturnType,
	RootState,
	unknown,
	Action<string>
>;
