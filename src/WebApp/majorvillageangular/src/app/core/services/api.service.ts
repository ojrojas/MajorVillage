import { HttpClient, HttpResponse } from "@angular/common/http";
import { Inject } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { RouteApiConstants } from "../enums/routeapi.constants";
import { IRequestService } from "../interfaces/irequest.interface";

export class ApiService implements IRequestService {

    constructor(@Inject(HttpClient) private httpClient: HttpClient) { }

    get<T>(routeApi: RouteApiConstants, params: any): Observable<HttpResponse<T>> {
        return this.httpClient.get<T>(`${environment.BaseUrlApi}/${routeApi}/${params}`, { observe: 'response' });
    }
    post<T>(routeApi: RouteApiConstants, body: any): Observable<HttpResponse<T>> {
        return this.httpClient.post<T>(`${environment.BaseUrlApi}/${routeApi}`, body, { observe: 'response' });
    }
    put<T>(routeApi: RouteApiConstants, body: any): Observable<HttpResponse<T>> {
        return this.httpClient.put<T>(`${environment.BaseUrlApi}/${routeApi}`, body, { observe: 'response' });
    }
    delete<T>(routeApi: RouteApiConstants): Observable<HttpResponse<T>> {
        return this.httpClient.delete<T>(`${environment.BaseUrlApi}/${routeApi}`, { observe: 'response' });
    }
    patch<T>(routeApi: RouteApiConstants, body: any): Observable<HttpResponse<T>> {
        return this.httpClient.patch<T>(`${environment.BaseUrlApi}/${routeApi}`, body, { observe: 'response' });
    }
}