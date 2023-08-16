import { createAsyncThunk } from "@reduxjs/toolkit";
import { ILoginRequest } from "../../core/model/login/login.request";
import { ILoginResponse } from "../../core/model/login/login.response";
import HttpClient from "../../core/services/api.service";
import { HttpRoutes } from "../../core/constants/contants.http";

export const login = createAsyncThunk<any, ILoginRequest>("login/login", (loginRequest: ILoginRequest) => {
    loginRequest.client_id = process.env.REACT_APP_CLIENT_ID!;
    loginRequest.client_secret = process.env.REACT_APP_CLIENT_SECRET!;
    loginRequest.scope = process.env.REACT_APP_SCOPES!;

    let formData = new URLSearchParams();
    formData.append("grant_type", "password");
    formData.append("username", loginRequest.username);
    formData.append("password", loginRequest.password);
    formData.append("scope", loginRequest.scope);
    formData.append("client_id", loginRequest.client_id);
    formData.append("client_secret", loginRequest.client_secret);
    const api = new HttpClient();

    const response = api.Post<ILoginResponse>(HttpRoutes.login, formData);
    return response;
});