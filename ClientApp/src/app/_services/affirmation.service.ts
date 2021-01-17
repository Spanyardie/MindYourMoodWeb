import { HttpClient } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Affirmation, IAffirmation } from '../_model/affirmation';

@Injectable({
  providedIn: 'root'
})
export class AffirmationService {
  baseUrl = environment.apiUrl;
  affirmation: Affirmation;

  constructor(private http: HttpClient) { }

  getAffirmation(id: number) {
    return this.http.get<IAffirmation>(this.baseUrl + 'affirmation/getaffirmation/' + id.toString());
  }

  getAffirmationsForUser(userId: number) {
    return this.http.get<IAffirmation[]>(this.baseUrl + 'affirmation/getaffirmations/' + userId.toString());
  }

  createAffirmation(affirmation: IAffirmation) {
    var retval = this.http.post<Affirmation>(this.baseUrl + 'affirmation/createaffirmation/', affirmation)
      .subscribe(result => {
        console.log(result);
        error => {
          console.log(error);
        }
      });
    console.log(retval);
  }

  removeAffirmation(id: number) {
    return this.http.delete<IAffirmation>(this.baseUrl + 'affirmation/removeaffirmation/' + id.toString()).subscribe(result => {
      console.log(result);
      error => {
        console.log(error);
      }
    })
  }
}
