import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { Select } from 'primeng/select'; 

import { AssetService } from '../../services/asset.service';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-assets',
  imports: [CommonModule,TableModule,ProgressSpinnerModule,DialogModule,ButtonModule,ToastModule,ReactiveFormsModule, Select],
  providers: [MessageService],
  templateUrl: './assets.html',
  styleUrl: './assets.css',
})
export class AssetComponent implements OnInit{
  
  assets: any[] = [];
  categories: any[] = [];

  displayDialog = false;
  isEdit = false;

  loading = false;

  assetForm!: FormGroup;
  selectedId: number | null = null;

  constructor(private assetService: AssetService,
    private categoryService: CategoryService,
    private fb: FormBuilder,
    private messageService: MessageService) {}

  ngOnInit(): void {
    this.loadAssets();
    this.loadCategories();

    this.assetForm = this.fb.group({
      assetName: ['', Validators.required],
      categoryId: ['', Validators.required],
      description: ['']
    });

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

    loadCategories() {
    this.categoryService.getAll().subscribe({
      next: (data) => {
        this.categories = data;
        console.log(data);
      },
      error: (err) => {
        console.error(err);
      }
    });
  }

  openNew() {
    this.assetForm.reset();
    this.isEdit = false;
    this.selectedId = null;
    this.displayDialog = true;
  }

  edit(asset: any) {
    this.assetForm.patchValue(asset);
    this.selectedId = asset.id;
    this.isEdit = true;
    this.displayDialog = true;
  }

  save() {
    if (this.assetForm.invalid) return;

    const data = this.assetForm.value;

    if (this.isEdit && this.selectedId) {
      this.assetService.updateAsset(this.selectedId, data).subscribe(() => {
        this.success('Updated');
      });
    } else {
      this.assetService.createAsset(data).subscribe(() => {
        this.success('Created');
      });
    }
  }

  delete(id: number) {
    if (!confirm('Delete this asset?')) return;

    this.assetService.deleteAsset(id).subscribe(() => {
      this.success('Deleted');
    });
  }

  success(msg: string) {
    this.messageService.add({
      severity: 'success',
      summary: 'Success',
      detail: msg
    });

    this.displayDialog = false;
    this.loadAssets();
  }
}
