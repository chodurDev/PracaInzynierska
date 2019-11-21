import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FirstAidKitService {
  baseUrl = environment.urlAddress;

  constructor(private http: HttpClient) {}

  GetuserMedicines(id: number) {
    return this.http.get<Medicine[]>(this.baseUrl + '/fak/' + id);
  }
}
export interface Medicine {
  medicineID: number;
  name: string;
  firstAidKitMedicines?: any;
}