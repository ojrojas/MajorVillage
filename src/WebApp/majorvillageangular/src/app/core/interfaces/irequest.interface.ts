import { Observable } from "rxjs";
import { HttpResponse } from '@angular/common/http';
import { RouteApiConstants } from '../enums/routeapi.constants';
import { IDictionary } from "../models/idictionary";

export interface IRequestService {
    get<T>(routeApi: RouteApiConstants, params: IDictionary[]): Observable<HttpResponse<T>>;
    post<T>(routeApi: RouteApiConstants, body: any): Observable<HttpResponse<T>>;
    put<T>(routeApi: RouteApiConstants, body: any): Observable<HttpResponse<T>>;
    delete<T>(routeApi: RouteApiConstants, params: IDictionary[]): Observable<HttpResponse<T>>;
    patch<T>(routeApi: RouteApiConstants, body: any): Observable<HttpResponse<T>>;
}