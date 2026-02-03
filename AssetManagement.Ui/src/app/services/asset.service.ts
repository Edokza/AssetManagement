import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Asset } from "../models/asset.model";

@Injectable({
  providedIn: 'root'
})
export class AssetService {
    
    private apiUrl = 'https://localhost:7078/api/assets';

    constructor(private http: HttpClient) {}

    //Assets
    getAssets(): Observable<Asset[]> {
        return this.http.get<Asset[]>(this.apiUrl);
    }

    //Get Asset by ID
    getAssetById(id: number): Observable<Asset> {
        return this.http.get<Asset>(`${this.apiUrl}/${id}`);
    }

    //Create Asset
    createAsset(asset: Asset): Observable<Asset> {
        return this.http.post<Asset>(this.apiUrl, asset);
    }

    //Update Asset
    updateAsset(id: number, asset: Asset): Observable<Asset> {
        return this.http.put<Asset>(`${this.apiUrl}/${id}`, asset);
    }

    //Delete Asset
    deleteAsset(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`);
    }

}