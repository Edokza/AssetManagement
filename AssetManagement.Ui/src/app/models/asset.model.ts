import { Category } from './category.model';

export interface Asset {
  assetID: number;
  assetName: string;
  serialNumber?: string;
  categoryID: number;
  category?: Category;
}