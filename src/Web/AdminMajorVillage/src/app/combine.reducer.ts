import { combineReducers } from "@reduxjs/toolkit";
import loginSlice from "./pages/login/redux/login.slice";
import snackbarSlice from "./components/snackbar/redux/snackbar.slice";
import loaderSlice from "./components/loaders/redux/loader.slice";
import typeusersSlice from "./pages/typeusers/redux/typeusers.slice";

export const rootReducer = combineReducers({
    login: loginSlice,
    snackbar: snackbarSlice,
    loader: loaderSlice, 
    typeUsers: typeusersSlice
})