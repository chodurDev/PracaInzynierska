import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Allergies } from '../_model/Allergies';

let httpOptions = {
  headers: new HttpHeaders()
};

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.urlAddress;

  constructor(private http: HttpClient) {
    httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
  }

  GetUserAllergies(id: number) {
    return this.http.get(
      this.baseUrl + '/fak/getUserAllergies/' + id,
      httpOptions
    );
  }

  AddAllergyToUserAllergies(userID: number, allergies: Allergies[]) {
    return this.http.post(
      this.baseUrl + '/fak/addAllergyToUserAllergies/' + userID,
      allergies,
      httpOptions
    );
  }

  DeleteUserAllergy(allergyId: number, userId: number) {
    return this.http.delete(
      this.baseUrl + '/fak/deleteUserAllergy/' + allergyId + '/' + userId,
      httpOptions
    );
  }
}