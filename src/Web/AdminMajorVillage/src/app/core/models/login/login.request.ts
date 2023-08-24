export interface ILoginRequest {
    username: string;
    password: string;
    grant_type: string | undefined;
    scope: string | undefined;
    client_id: string | undefined;
    client_secret: string | undefined;
}

export interface ILogin {
    username: string;
    password: string;
}