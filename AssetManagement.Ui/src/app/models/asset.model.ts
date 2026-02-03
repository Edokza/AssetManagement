import { Category } from './category.model';

export interface Asset {
  assetId: number;
  assetName: string;
  serialNumber?: string;
  categoryId: number;
  category: Category;
}