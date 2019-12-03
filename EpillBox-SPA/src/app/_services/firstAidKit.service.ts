import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { FirstAidKitMedicine } from '../_model/FirstAidKitMedicine';

@Injectable({
  providedIn: 'root'
})
export class FirstAidKitService {
  baseUrl = environment.urlAddress;

  constructor(private http: HttpClient) {}

  GetuserMedicines(id: number) {
    return this.http.get<FirstAidKitMedicine[]>(this.baseUrl + '/fak/' + id);
  }
  GetExpiredMedicines(id: number) {
    return this.http.get<FirstAidKitMedicine[]>(
      this.baseUrl + '/fak/expiredMedicines/' + id
    );
  }
  GetUserFirstAidKits(id: number) {
    return this.http.get(this.baseUrl + '/fak/getUserFirstAidKits/' + id);
  }
  GetUserChosenFirstAidKitMedicines(id: number) {
    return this.http.get<FirstAidKitMedicine[]>(
      this.baseUrl + '/fak/getUserChosenFirstAidKitMedicines/' + id
    );
  }
  GetUserTakenMedicines(id: number) {
    return this.http.get<FirstAidKitMedicine[]>(
      this.baseUrl + '/fak/getUserTakenMedicines/' + id
    );
  }
  UpdateFirstAidKitMedicine(fakMedicine: FirstAidKitMedicine) {
    return this.http
      .put(
        this.baseUrl + '/fak/' + fakMedicine.firstAidKitMedicineID,
        fakMedicine
      )
      .subscribe();
  }
  DeleteFAKMedicine(id: number) {
    return this.http.delete(this.baseUrl + '/fak/' + id).subscribe();
  }
}
