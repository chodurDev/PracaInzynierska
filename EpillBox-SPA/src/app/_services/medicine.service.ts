import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { MedicineToAdd } from '../_model/MedicineToAdd';

let httpOptions = {
  headers: new HttpHeaders()
};

@Injectable({
  providedIn: 'root'
})
export class MedicineService {
  baseUrl = environment.urlAddress;

  constructor(private http: HttpClient) {
    httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
  }

  GetAllMedicines() {
    return this.http.get(this.baseUrl + '/fak/getAllMedicines', httpOptions);
  }

  AddMedicineToShoppingBasket(userID: number, medicineID: number) {
    return this.http.post(
      this.baseUrl + '/fak/addMedicineToBuy/' + userID,
      medicineID,
      httpOptions
    );
  }

  GetMedicinesToShoppingBasket(userID: number) {
    return this.http.get(
      this.baseUrl + '/fak/getMedicinesToBuy/' + userID,
      httpOptions
    );
  }

  GetAllAllergies() {
    return this.http.get(this.baseUrl + '/fak/getAllAllergies', httpOptions);
  }

  AddMedicineToDatabase(medicine: MedicineToAdd) {
    return this.http.post(
      this.baseUrl + '/fak/addMedicine',
      medicine,
      httpOptions
    );
  }

  SendShoppingList(userID: number) {
    return this.http.get(
      this.baseUrl + '/fak/sendShoppingList/' + userID,
      httpOptions
    );
  }
}
