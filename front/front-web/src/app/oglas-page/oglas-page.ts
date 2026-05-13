import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { DecimalPipe } from '@angular/common';
import { Oglas } from '../Interfaces/oglas';

@Component({
  selector: 'app-oglas-page',
  imports: [RouterLink, DecimalPipe],
  templateUrl: './oglas-page.html',
  styleUrl: './oglas-page.css',
})
export class OglasPage implements OnInit {
  oglas: Oglas | undefined;
  loggedin: boolean = false;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.loggedin = localStorage.getItem('token') != null;
  }

  formatPhone(phone: number): string {
    const s = phone.toString();
    return '+' + s.slice(0, 3) + ' ' + s.slice(3, 5) + ' ' + s.slice(5, 8) + ' ' + s.slice(8);
  }
}
