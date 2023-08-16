import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';
import loginSlice from './login/redux/login.slice';
import snackbarSlice from './components/snackbar/redux/snackbar.slice';
import { throttle } from 'lodash';

export const store = configureStore({
  reducer: {
   login: loginSlice,
   snackbar: snackbarSlice
  },
});

store.subscribe(
	throttle(() => {
		if (process.env.NODE_ENV === "development") {
			console.info("state", store.getState());
			console.info("actions", store.dispatch);
		}
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
