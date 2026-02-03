import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TableModule } from 'primeng/table';
import { ProgressSpinnerModule } from 'primeng/progressspinner';

import { AssetService } from '../../services/asset.service';
import { Asset } from '../../models/asset.model';

@Component({
  selector: 'app-assets',
  imports: [CommonModule,TableModule,ProgressSpinnerModule],
  templateUrl: './assets.html',
  styleUrl: './assets.css',
})
export class AssetComponent implements OnInit{
  
  assets: Asset[] = [];
  loading = false;

  constructor(private assetService: AssetService) {}

  ngOnInit(): void {
    this.loadAssets();
  }

  loadAssets() {
    this.loading = true;

    this.assetService.getAssets().subscribe({
      next: (data) => {
        this.assets = data;
        this.loading = false;
        console.log(data);
      },
      error: (err) => {
        console.error(err);
        this.loading = false;
      }
    });}
}
