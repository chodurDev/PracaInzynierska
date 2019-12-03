import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { FirstAidKitMedicine } from '../_model/FirstAidKitMedicine';
import { UserFirstAidKit } from '../_model/UserFirstAidKit';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class FirstAidKitService {
  baseUrl = environment.urlAddress;

  constructor(private http: HttpClient) {}

  GetuserMedicines(id: number) {
    return this.http.get<FirstAidKitMedicine[]>(
      this.baseUrl + '/fak/' + id,
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
    return this.http.get(
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
    return this.http
      .put(
        this.baseUrl + '/fak/' + fakMedicine.firstAidKitMedicineID,
        fakMedicine,
        httpOptions
      )
      .subscribe();
  }
  DeleteFAKMedicine(id: number) {
    return this.http
      .delete(this.baseUrl + '/fak/' + id, httpOptions)
      .subscribe();
  }
  AddUFAK(uFAK: UserFirstAidKit) {
    return this.http.post<UserFirstAidKit>(this.baseUrl + '/fak/addUFAK', uFAK);
  }
}