import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { User } from '../_model/user';

@Injectable({
  providedIn: 'root'
})
export class BaseDataService<T> {
  baseUrl = environment.apiUrl;
  public class: string;
  public routeSingular: string;
  public routeMultiple: string;
  user: User;
  public item: any;
  returnType: any;

  constructor(private http: HttpClient) {
  }

  getItem<T>(id: number): Observable<T> {
    
    return this.http.get(this.baseUrl + this.class + '/get' + this.routeSingular + '/' + id.toString()).pipe(map((response: Response) => {
      this.returnType = <T><unknown>response;
      return <T><unknown>response;
    }));
  }

  //getItems<T>(user: User): Array<T> {
  //  return this.http.get(this.baseUrl + this.class + '/get' + this.routeMultiple + '/' + user.id.toString()).pipe(map((response: Response) => {
  //    this.returnType = Array < T >response;
  //    return Array < T > response;
  //  }));
  //}

  removeItem(id: number) {
    this.http.delete(this.baseUrl + this.class + '/remove' + this.routeSingular + '/' + id.toString(), {});
  }

  addItem<T>(userId: number, item: T) {
    this.http.post(this.baseUrl + this.class + '/create' + this.routeSingular + '/', userId, item);
  }

}
