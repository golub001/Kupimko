import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { Api } from '../services/api';

@Component({
  selector: 'app-login-page',
  imports: [FormsModule, RouterLink],
  templateUrl: './login-page.html',
  styleUrl: './login-page.css',
})
export class LoginPage {
  username: string = '';
  password: string = '';

  constructor(private api:Api,private router:Router){

  }


  login() {
    this.api.login(this.username,this.password).subscribe({
      next:(response:string)=>{
        console.log(response);
        localStorage.setItem("token",response);
        this.router.navigate(["/"])
      },
      error:(error)=>{
        console.log("Neuspesan login" + error.message);
      }
    })
  }
}
