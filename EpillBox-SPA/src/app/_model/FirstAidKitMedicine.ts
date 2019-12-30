export interface FirstAidKitMedicine {
  expirationDate?: Date | null;
  firstAidKitID?: number | null;
  firstAidKitMedicineID?: number | null;
  isTaken?: boolean | null;
  name: string;
  medicineID: number;
  remainingQuantity?: number | null;
  quantityInPackage?: number | null;
  fakName?: string | null;
  form?: string | null;
  producer?: string | null;
  activeSubstance?: string[] | null;
}
