import { Routes } from '@angular/router';

import { AssetComponent } from './pages/assets/assets';
import { CategoriesComponent } from './pages/categories/categories';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'assets',
    pathMatch: 'full'
  },
  {
    path: 'assets',
    component: AssetComponent
  },
  {
    path: 'categories',
    component: CategoriesComponent
  }
];
