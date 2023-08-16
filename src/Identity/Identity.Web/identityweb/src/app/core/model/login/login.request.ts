export interface ILoginRequest {
    grant_type: string;
    username: string;
    password: string;
    client_id: string; 
    client_secret: string;
    scope: string;
}