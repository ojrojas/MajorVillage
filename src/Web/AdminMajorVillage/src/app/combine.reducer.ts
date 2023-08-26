import { combineReducers } from "@reduxjs/toolkit";
import loginSlice from "./pages/login/redux/login.slice";
import snackbarSlice from "./components/snackbar/redux/snackbar.slice";

export const rootReducer = combineReducers({
    login: loginSlice,
    snackbar: snackbarSlice
})