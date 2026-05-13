import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Route, Router, RouterLink } from '@angular/router';
import { Api } from '../services/api';

@Component({
  selector: 'app-register-page',
  imports: [FormsModule, RouterLink],
  templateUrl: './register-page.html',
  styleUrl: './register-page.css',
})
export class RegisterPage {
  username:string="";
  password:string=""

  constructor(private api:Api,private router:Router){

  }

  register() {
    this.api.register(this.username,this.password).subscribe({
      next:(response:string)=>{
        localStorage.setItem("token",response);
        this.router.navigate(["/"])
      }
    })
  }
}
