import { FirstAidKitMedicine } from './FirstAidKitMedicine';

export interface Medicine {
  medicineID: number;
  name: string;
  firstAidKitMedicines?: FirstAidKitMedicine[];
  quantityInPackage: number;
}
