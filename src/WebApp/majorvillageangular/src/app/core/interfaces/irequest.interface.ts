import { Observable } from "rxjs";
import { HttpResponse } from '@angular/common/http';
import { RouteApiConstants } from '../enums/routeapi.constants';

export interface IRequestService {
    get<T>(routeApi: RouteApiConstants, params: any): Observable<HttpResponse<T>>;
    post<T>(routeApi: RouteApiConstants, body: any): Observable<HttpResponse<T>>;
    put<T>(routeApi: RouteApiConstants, body: any): Observable<HttpResponse<T>>;
    delete<T>(routeApi: RouteApiConstants): Observable<HttpResponse<T>>;
    patch<T>(routeApi: RouteApiConstants, body: any): Observable<HttpResponse<T>>;
}