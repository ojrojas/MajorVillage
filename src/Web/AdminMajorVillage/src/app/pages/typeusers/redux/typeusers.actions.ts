import { createAsyncThunk } from "@reduxjs/toolkit";
import { ICreateTypeUserRequest, ICreateTypeUserResponse, IDeleteTypeUserRequest, IDeleteTypeUserResponse, IGetAllTypeUserResponse, IGetTypeUserByIdRequest, IGetTypeUserByIdResponse, IUpdateTypeUserRequest, IUpdateTypeUserResponse } from "../../../core/models/type/typeuser.dtos";
import HttpClient from "../../../core/services/api.service";
import { HttpRoutes } from "../../../core/constants/http/http.route";

export const createTypeUser = createAsyncThunk<ICreateTypeUserResponse, ICreateTypeUserRequest>("typeuser/create", async (request: ICreateTypeUserRequest)=> {
    const httpClient = new HttpClient();
    return await httpClient.Post<ICreateTypeUserResponse>(HttpRoutes.typeUsers.createTypeUser, request);
});

export const updateTypeUser = createAsyncThunk<IUpdateTypeUserResponse, IUpdateTypeUserRequest>("typeuser/update", async (request: IUpdateTypeUserRequest) => {
    const httpClient = new HttpClient();
    return await httpClient.Patch(HttpRoutes.typeUsers.updateTypeUser, request);
});

export const deleteTypeUser = createAsyncThunk<IDeleteTypeUserResponse, IDeleteTypeUserRequest>("typeuser/delete", async (request: IDeleteTypeUserRequest) => {
    const httpClient = new HttpClient();
    return await httpClient.Delete(HttpRoutes.typeUsers.deleteTypeUserById + request.id);
});

export const getTypeUserById = createAsyncThunk<IGetTypeUserByIdResponse, IGetTypeUserByIdRequest>("typeuser/gettypeuserbyid", async (request: IDeleteTypeUserRequest)=> {
    const httpClient = new HttpClient();
    return await httpClient.Get(HttpRoutes.typeUsers.getTypeUserById + request.id);
});

export const getAllTypeUsers = createAsyncThunk<IGetAllTypeUserResponse>("typeuser/getalltypeusers", async () => {
    const httpClient = new HttpClient();
    return await httpClient.Get(HttpRoutes.typeUsers.getAllTypeUsers);
})