import { Medicine } from './Medicine';

export interface FirstAidKitMedicine {
  expirationDate: Date;
  firstAidKit?: any;
  firstAidKitID: number;
  firstAidKitMedicineID: number;
  isTaken: boolean;
  medicine: Medicine;
  medicineID: number;
  remainingQuantity: number;
}
