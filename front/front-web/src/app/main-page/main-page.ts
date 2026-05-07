import { Component, OnInit } from '@angular/core';
import { RouterLink } from "@angular/router";
import { SlicePipe, DecimalPipe } from '@angular/common';
import { Oglas } from '../Interfaces/oglas';
import { CATEGORIES } from '../constants/categories';
import { OglasService } from '../services/oglas.service';

@Component({
  selector: 'app-main-page',
  imports: [RouterLink, SlicePipe, DecimalPipe],
  templateUrl: './main-page.html',
  styleUrl: './main-page.css',
})
export class MainPage implements OnInit {
  oglasi: Oglas[];

  constructor(private oglasService: OglasService) {
    this.oglasi = this.oglasService.oglasi;
  }

  kategorije = CATEGORIES.map(k => ({ ...k, selektovana: false }));

  loggedin: boolean = false;

  toggleKategorija(id: number) {
    const kat = this.kategorije.find(k => k.id === id);
    if (kat) kat.selektovana = !kat.selektovana;
  }

  ngOnInit(): void {
    this.loggedin = localStorage.getItem("token") != null;
  }
}
