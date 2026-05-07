import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { DecimalPipe } from '@angular/common';
import { Oglas } from '../Interfaces/oglas';
import { OglasService } from '../services/oglas.service';
import { CATEGORIES } from '../constants/categories';

@Component({
  selector: 'app-oglas-page',
  imports: [RouterLink, DecimalPipe],
  templateUrl: './oglas-page.html',
  styleUrl: './oglas-page.css',
})
export class OglasPage implements OnInit {
  oglas: Oglas | undefined;
  kategorijaNaziv: string = '';
  loggedin: boolean = false;

  constructor(private route: ActivatedRoute, private oglasService: OglasService) {}

  ngOnInit(): void {
    this.loggedin = localStorage.getItem('token') != null;
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.oglas = this.oglasService.getById(id);
    if (this.oglas) {
      this.kategorijaNaziv = CATEGORIES[this.oglas.category]?.name ?? 'Nepoznato';
    }
  }

  formatPhone(phone: number): string {
    const s = phone.toString();
    return '+' + s.slice(0, 3) + ' ' + s.slice(3, 5) + ' ' + s.slice(5, 8) + ' ' + s.slice(8);
  }
}
