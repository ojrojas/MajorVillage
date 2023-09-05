import { ITypeUser } from "./typeuser.model";

export interface ICreateTypeUserRequest {
    typeUser: ITypeUser;
}

export interface ICreateTypeUserResponse {
    typeUserCreated: ITypeUser;
}

export interface IUpdateTypeUserRequest {
    typeUser: ITypeUser
}

export interface IUpdateTypeUserResponse {
    typeUserUpdated: ITypeUser
}

export interface IDeleteTypeUserRequest {
    id: string;
}

export interface IDeleteTypeUserResponse {
    isTypeUserDeleted: boolean;
}

export interface IGetAllTypeUserResponse {
    typeUsers: ITypeUser[];
}

export interface IGetTypeUserByIdRequest {
    id: string;
}

export interface IGetTypeUserByIdResponse {
    typeUser: ITypeUser
}