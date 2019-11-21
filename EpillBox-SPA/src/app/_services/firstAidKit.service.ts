import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Medicine } from '../_model/Medicine';

@Injectable({
  providedIn: 'root'
})
export class FirstAidKitService {
  baseUrl = environment.urlAddress;

  constructor(private http: HttpClient) {}

  GetuserMedicines(id: number) {
    return this.http.get<Medicine[]>(this.baseUrl + '/fak/' + id);
  }
  GetExpiredMedicines(id: number) {
    return this.http.get<Medicine[]>(this.baseUrl + '/fak/expiredMedicines/' + id);
  }
}
