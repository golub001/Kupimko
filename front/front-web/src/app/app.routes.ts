import { Routes } from '@angular/router';
import { MainPage } from './main-page/main-page';
import { LoginPage } from './login-page/login-page';
import { RegisterPage } from './register-page/register-page';
import { OglasPage } from './oglas-page/oglas-page';

export const routes: Routes = [
    {path:"",component:MainPage},
    {path:"login",component:LoginPage},
    {path:"register",component:RegisterPage},
    {path:"oglas/:id",component:OglasPage}
];
