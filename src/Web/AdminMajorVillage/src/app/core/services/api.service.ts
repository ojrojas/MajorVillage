import { RootState } from "../../store";
import StorageService from "./storage.service";

class HttpClient {
    private headers: Headers;

    constructor() {
        this.headers = new Headers();
        const state = StorageService.GetState() as RootState;
        this.headers.append("Content-Type", "application/json");
        this.headers.append("authorization", `Bearer ${state.login.loginResponse?.access_token}`)
    }

    public Login = async <T>(url: string, body: any): Promise<T> => {
        try {
            this.headers.delete("Content-Type");
            this.headers.delete("Accept");
            this.headers.append("Content-Type", "application/x-www-form-urlencoded");
            this.headers.append("Accept", "*/*");
            const response = await fetch(url, {
                method:'post',
                headers: this.headers,
                body: body,
            });
            return response.json() as T;
        } catch (error) {
            throw new Error(`Error: -- ${error}`);
        }
    }

    public Post = async <T>(url: string, body: any): Promise<T> => {
        try {
            const response = await fetch(url, {
                method:'post',
                headers: this.headers,
                body: body
            });
            return response.json() as T;
        } catch (error) {
            throw new Error(`Error: -- ${error}`);
        }
    }

    public Put = async <T>(url: string, body: any): Promise<T> => {
        try {
            const response = await fetch(url, {
                method:'put',
                headers: this.headers,
                body: body
            });
            return response.json() as T;
        } catch (error) {
            throw new Error(`Error: -- ${error}`);
        }
    }

    public Patch = async <T>(url: string, body: any): Promise<T> => {
        try {
            const response = await fetch(url, {
                method:'patch',
                headers: this.headers,
                body: body
            });
            return response.json() as T;
        } catch (error) {
            throw new Error(`Error: -- ${error}`);
        }
    }

    public Get = async <T>(url: string): Promise<T> => {
        try {
            const response = await fetch(url, {
                method:'get',
                headers: this.headers,
            });
            return response.json() as T;
        } catch (error) {
            throw new Error(`Error: -- ${error}`);
        }
    }

    public Delete = async <T>(url: string): Promise<T> => {
        try {
            const response = await fetch(url, {
                method:'delete',
                headers: this.headers,
            });
            return response.json() as T;
        } catch (error) {
            throw new Error(`Error: -- ${error}`);
        }
    }
}

export default HttpClient;