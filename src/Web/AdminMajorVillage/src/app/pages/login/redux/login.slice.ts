import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { ILoginRequest } from "../../../core/models/login/login.request";
import { ILoginResponse } from "../../../core/models/login/login.response";
import { IUser } from "../../../core/models/user/user.model";
import { login } from "./login.actions";
import StorageService from "../../../core/services/storage.service";

interface IState {
    loginRequest: ILoginRequest | undefined;
    loginResponse: ILoginResponse | undefined;
    loading: boolean;
    error: any;
    logged: boolean;
    user: IUser | undefined;
}

const InitialState: IState = {
    loginRequest: undefined,
    loginResponse: undefined,
    loading: false,
    error: undefined,
    logged: false,
    user: undefined
}

const loginSlice = createSlice({
    name: 'login',
    initialState: InitialState,
    reducers: {
        setlogged: (state, action: PayloadAction<boolean>) => {
            state.logged = action.payload
        },
        setlogout:(state) => {
            state.logged= false;
            StorageService.ClearState();
        }
    },
    extraReducers: builder => {
        builder.addCase(login.pending, (state, action) => {
            state.loading = true;
            state.loginRequest = action.payload;
        })
        builder.addCase(login.fulfilled, (state, action) => {
            state.loading = false;
            state.loginResponse = action.payload;
        })
        builder.addCase(login.rejected, (state, action) => {
            state.loading = false;
            state.loginResponse = undefined;
            state.loginRequest = undefined;
            state.logged = false;
        })
    }
})

export default loginSlice.reducer;
export const { setlogged ,setlogout } = loginSlice.actions;