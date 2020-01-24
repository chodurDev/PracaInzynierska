import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { FirstAidKitMedicine } from '../_model/FirstAidKitMedicine';
import { UserFirstAidKit } from '../_model/UserFirstAidKit';

let httpOptions = {
  headers: new HttpHeaders()
};

@Injectable({
  providedIn: 'root'
})
export class FirstAidKitService {
  baseUrl = environment.urlAddress;

  constructor(private http: HttpClient) {
    httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
  }

  GetuserMedicines(id: number) {
    return this.http.get<FirstAidKitMedicine[]>(
      this.baseUrl + '/fak/' + id,
      httpOptions
    );
  }
  GetShortTermMedicines(id: number, days: number) {
    return this.http.get<FirstAidKitMedicine[]>(
      this.baseUrl + '/fak/shortTermMedicines/' + id + '/' + days,
      httpOptions
    );
  }
  GetExpiredMedicines(id: number) {
    return this.http.get<FirstAidKitMedicine[]>(
      this.baseUrl + '/fak/expiredMedicines/' + id,
      httpOptions
    );
  }
  GetUserFirstAidKits(id: number) {
    return this.http.get<UserFirstAidKit[]>(
      this.baseUrl + '/fak/getUserFirstAidKits/' + id,
      httpOptions
    );
  }
  GetUserChosenFirstAidKitMedicines(id: number) {
    return this.http.get<FirstAidKitMedicine[]>(
      this.baseUrl + '/fak/getUserChosenFirstAidKitMedicines/' + id,
      httpOptions
    );
  }
  GetUserTakenMedicines(id: number) {
    return this.http.get<FirstAidKitMedicine[]>(
      this.baseUrl + '/fak/getUserTakenMedicines/' + id,
      httpOptions
    );
  }
  UpdateFirstAidKitMedicine(fakMedicine: FirstAidKitMedicine) {
    return this.http.put(this.baseUrl + '/fak', fakMedicine, httpOptions);
  }
  DeleteFAKMedicine(id: number) {
    return this.http.delete(
      this.baseUrl + '/fak/deleteFAKMedicine/' + id,
      httpOptions
    );
  }
  AddUFAK(uFAK: UserFirstAidKit) {
    return this.http.post<UserFirstAidKit>(
      this.baseUrl + '/fak/addUFAK',
      uFAK,
      httpOptions
    );
  }
  DeleteFAK(firstAidKitID: number) {
    return this.http.delete(
      this.baseUrl + '/fak/deleteFAK/' + firstAidKitID,
      httpOptions
    );
  }
  AddFAKMedicine(fakMedicine: FirstAidKitMedicine) {
    return this.http.post(
      this.baseUrl + '/fak/addFAKMedicine',
      fakMedicine,
      httpOptions
    );
  }
  AddMedicineToAllFAK(fakMedicine: FirstAidKitMedicine, id: number) {
    return this.http.post(
      this.baseUrl + '/fak/addMedicineToAllFAK/' + id,
      fakMedicine,
      httpOptions
    );
  }

  SetSchedule(fakMedicine: FirstAidKitMedicine) {
    console.log(fakMedicine);
    return this.http.put(
      this.baseUrl + '/fak/setSchedule',
      fakMedicine,
      httpOptions
    );
  }

  GetMedicinesUserCantTake(userID: number) {
    return this.http.get(
      this.baseUrl + '/fak/getMedicinesUserCantTake/' + userID,
      httpOptions
    );
  }
}
