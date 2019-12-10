import { Medicine } from './Medicine';

export interface FirstAidKitMedicine {
  expirationDate?: Date | null;
  firstAidKitID: number;
  firstAidKitMedicineID: number;
  isTaken: boolean;
  name: string;
  medicineID: number;
  remainingQuantity: number;
  quantityInPackage: number;
}
