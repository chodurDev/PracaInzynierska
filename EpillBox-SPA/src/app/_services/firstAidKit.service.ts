import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FirstAidKitService {
  baseUrl = 'http://localhost:5000/api';
  constructor(private http: HttpClient) {}

  GetuserMedicines(id: number):Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + '/fak/' + id);
  }
}
