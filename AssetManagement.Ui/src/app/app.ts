import { Component, signal } from '@angular/core';
import { RouterOutlet, RouterLink  } from '@angular/router';
import { MenubarModule } from 'primeng/menubar';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink, MenubarModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  menuItems = [
    {
      label: 'Assets',
      icon: 'pi pi-box',
      routerLink: '/assets'
    },
    {
      label: 'Categories',
      icon: 'pi pi-tags',
      routerLink: '/categories'
    }
  ];
}
