import { createAsyncThunk } from "@reduxjs/toolkit";
import { ILoginResponse } from "../../../core/models/login/login.response";
import HttpClient from "../../../core/services/api.service";
import { HttpRoutes } from "../../../core/constants/http/http.route";
import { ILogin } from "../../../core/models/login/login.request";

export const login = createAsyncThunk<ILoginResponse, ILogin>('login/login', async (login: ILogin) => {
    const api = new HttpClient();

    const client_id = process.env.REACT_APP_CLIENT_ID;
    const scope = process.env.REACT_APP_SCOPE;
    const client_secret = process.env.REACT_APP_SECRET_CLIENT;
    const grant_type = process.env.REACT_APP_GRAND_TYPE;

    let formData = new URLSearchParams();
		formData.append("grant_type",grant_type!);
		formData.append("username", login.username);
		formData.append("password",login.password);
		formData.append("scope", scope!);
		formData.append("client_id",client_id!);
		formData.append("client_secret", client_secret!);

    const response = await api.Login<ILoginResponse>(HttpRoutes.login, formData);
    return response;
});

export const logout = createAsyncThunk("login/logout", async () => {
    return false;
});