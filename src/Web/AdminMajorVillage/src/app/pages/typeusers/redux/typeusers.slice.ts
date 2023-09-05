import { createSlice } from "@reduxjs/toolkit";
import { ICreateTypeUserRequest, ICreateTypeUserResponse, IDeleteTypeUserRequest, IDeleteTypeUserResponse, IGetAllTypeUserResponse, IGetTypeUserByIdRequest, IGetTypeUserByIdResponse, IUpdateTypeUserRequest, IUpdateTypeUserResponse } from "../../../core/models/type/typeuser.dtos";
import { ITypeUser } from "../../../core/models/type/typeuser.model";
import { createTypeUser, getAllTypeUsers } from "./typeusers.actions";

interface State {
    typeUser?: ITypeUser;
    createTypeUserRequest?: ICreateTypeUserRequest;
    createTypeUserResponse?: ICreateTypeUserResponse;
    updateTypeUserRequest?: IUpdateTypeUserRequest;
    updateTypeUserResponse?: IUpdateTypeUserResponse;
    getTypeUserByIdRequest?: IGetTypeUserByIdRequest;
    getTypeUserByIdResponse?: IGetTypeUserByIdResponse;
    getAllTypeUserResponse?: IGetAllTypeUserResponse;
    deleteTypeUserRequest?: IDeleteTypeUserRequest;
    deleteTypeUserResponse?: IDeleteTypeUserResponse;
    error: any;
}

const initialState: State = {
    typeUser: undefined,
    createTypeUserRequest: undefined,
    createTypeUserResponse: undefined,
    updateTypeUserRequest: undefined,
    updateTypeUserResponse: undefined,
    getTypeUserByIdRequest: undefined,
    getTypeUserByIdResponse: undefined,
    getAllTypeUserResponse: undefined,
    deleteTypeUserRequest: undefined,
    deleteTypeUserResponse: undefined,
    error: undefined
}

const typeUserSlice = createSlice({
    name:'typeUser',
    initialState,
    reducers: {},
    extraReducers: builder => {
        builder.addCase(createTypeUser.pending, (state, payload) => {
            state.createTypeUserRequest = payload.payload;
        });
        builder.addCase(createTypeUser.fulfilled, (state, payload) => {
            state.createTypeUserResponse = payload.payload;
            state.createTypeUserRequest = undefined;
        });
        builder.addCase(createTypeUser.rejected, (state, payload) => {
            state.error = payload.error;
        });
        builder.addCase(getAllTypeUsers.pending, (state, payload) => {
            
        });
        builder.addCase(getAllTypeUsers.fulfilled, (state, payload) => {
            state.getAllTypeUserResponse = payload.payload;
        });
        builder.addCase(getAllTypeUsers.rejected, (state, payload) => {
            state.getAllTypeUserResponse = undefined;
            state.error = payload.error;
        })
    }
});

export default typeUserSlice.reducer;