import { createSlice } from "@reduxjs/toolkit";
import { login } from "./login.action";
import { ILoginRequest } from "../../core/model/login/login.request";
import { ILoginResponse } from "../../core/model/login/login.response";

interface State {
    loading:boolean;
    loginRequest : ILoginRequest | undefined;
    loginResponse: ILoginResponse| undefined;
    error: any;
}

const InitialState:State = {
    loading :false,
    loginRequest: undefined,
    loginResponse : undefined,
    error: undefined
}

const loginSlice = createSlice({
    name: 'login',
    initialState: InitialState,
    extraReducers: builder => {
        builder.addCase(login.pending, (state, action) => {
            state.loading = true;
            state.loginRequest = action.payload;
        });
        builder.addCase(login.fulfilled, (state, action) => {
            state.loading = false;
            state.loginResponse = action.payload;
        });
        builder.addCase(login.rejected, (state, action) => {
            state.loading = false;
            state.loginRequest = undefined;
            state.loginResponse = undefined;
        });
    },
    reducers: {}
});


export default loginSlice.reducer;