import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Medicine } from '../_model/Medicine';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class MedicineService {
  baseUrl = environment.urlAddress;

  constructor(private http: HttpClient) {}

  GetAllMedicines() {
    return this.http
      .get<Medicine[]>(this.baseUrl + '/fak/getAllMedicines', httpOptions);
  }
}
