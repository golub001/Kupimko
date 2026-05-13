import { Component, OnInit, signal } from '@angular/core';
import { RouterLink } from "@angular/router";
import { SlicePipe, DecimalPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Oglas } from '../Interfaces/oglas';
import { Category } from '../Interfaces/Category';
import { Api } from '../services/api';

@Component({
  selector: 'app-main-page',
  imports: [RouterLink, SlicePipe, DecimalPipe, FormsModule],
  templateUrl: './main-page.html',
  styleUrl: './main-page.css',
})
export class MainPage implements OnInit {
  oglasi: Oglas[] = [];
  loggedin: boolean = false;
  categories: Category[] = [];
  loaded = signal<boolean>(false);
  oglasLoaded = signal<boolean>(false);

  searchQuery: string = '';
  searchLocation: string = '';
  searchMinPrice: number | null = null;
  searchMaxPrice: number | null = null;
  currentPage: number = 1;
  totalPages: number = 1;
  totalOglasi: number = 0;

  constructor(private api: Api) {}

  ngOnInit(): void {
    this.loggedin = localStorage.getItem("token") != null;
    this.api.getkategorije().subscribe({
      next: (response: Category[]) => {
        this.categories = response;
        this.loaded.set(true);
      }
    });
    this.search();
  }

  search(page: number = 1): void {
    this.currentPage = page;
    this.oglasLoaded.set(false);
    this.api.searchOglasi(this.searchQuery, this.searchLocation, this.searchMinPrice, this.searchMaxPrice, page).subscribe({
      next: (response) => {
        this.oglasi = response.items;
        this.totalPages = response.totalPages;
        this.totalOglasi = response.total;
        this.oglasLoaded.set(true);
      }
    });
  }
}
