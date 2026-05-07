import { Injectable } from '@angular/core';
import { Oglas } from '../Interfaces/oglas';

@Injectable({ providedIn: 'root' })
export class OglasService {
  readonly oglasi: Oglas[] = [
    {
      id: 1,
      title: "iPhone 14 Pro - odlično stanje",
      description: "Prodajem iPhone 14 Pro, 256GB, Space Black. Korišćen svega godinu dana, bez ogrebotina. Dolazi sa originalnom kutijom i punjačem.",
      phone_number: 381641234567,
      created_by: "Marko Marković",
      price: 85000,
      currency: 0,
      image: "https://picsum.photos/seed/phone/400/300",
      category: 0,
      location: "Beograd"
    },
    {
      id: 2,
      title: "Samsung 65\" 4K QLED TV",
      description: "Prodajem Samsung QLED televizor, 65 inča, 4K rezolucija. Kupljen pre 6 meseci, potpuno ispravan, bez oštećenja.",
      phone_number: 381611234567,
      created_by: "Ana Jovanović",
      price: 750,
      currency: 1,
      image: "https://picsum.photos/seed/tv/400/300",
      category: 1,
      location: "Novi Sad"
    },
    {
      id: 3,
      title: "Mountain bike Cube Aim 2023",
      description: "Prodajem bicikl Cube Aim, veličina okvira L, 21 brzina, hidraulične kočnice. Malo korišćen, u odličnom stanju.",
      phone_number: 381651234567,
      created_by: "Nikola Petrović",
      price: 45000,
      currency: 0,
      image: "https://picsum.photos/seed/bike/400/300",
      category: 2,
      location: "Kragujevac"
    },
    {
      id: 4,
      title: "PS5 + 3 igrice",
      description: "Prodajem PlayStation 5 disc verziju sa 3 igrice: FIFA 24, Spider-Man 2 i God of War Ragnarok. Sve originalno, u kutiji.",
      phone_number: 381621234567,
      created_by: "Stefan Nikolić",
      price: 600,
      currency: 1,
      image: "https://picsum.photos/seed/ps5/400/300",
      category: 3,
      location: "Niš"
    },
    {
      id: 5,
      title: "Sofa na razvlačenje - siva",
      description: "Prodajem sofu na razvlačenje, siva boja, dimenzije 220x90cm. Korišćena 2 godine, čista i bez oštećenja. Moguć dogovor oko cene.",
      phone_number: 381631234567,
      created_by: "Jelena Đorđević",
      price: 28000,
      currency: 0,
      image: "https://picsum.photos/seed/sofa/400/300",
      category: 4,
      location: "Subotica"
    },
    {
      id: 6,
      title: "MacBook Air M2 - 8GB/256GB",
      description: "Prodajem MacBook Air M2 chip, 8GB RAM, 256GB SSD, Midnight boja. Garancija još 10 meseci, dolazi sa originalnim punjačem.",
      phone_number: 381691234567,
      created_by: "Milica Stojanović",
      price: 1100,
      currency: 1,
      image: "https://picsum.photos/seed/mac/400/300",
      category: 0,
      location: "Beograd"
    }
  ];

  getById(id: number): Oglas | undefined {
    return this.oglasi.find(o => o.id === id);
  }
}
