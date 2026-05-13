import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../Interfaces/Category';
import { Oglas } from '../Interfaces/oglas';
import { PagedResult } from '../Interfaces/PagedResult';

@Injectable({
  providedIn: 'root',
})
export class Api {
  ip="http://localhost:5026"

  constructor(private http:HttpClient){

  }
  login(username:string,password:string):Observable<string>{
      var payload={
        username:username,
        password:password
      }
      return this.http.post(this.ip+"/api/User/login",payload,{responseType:"text"});
  }
  register(username:string,password:string):Observable<string>{
    var payload={
      username:username,
      password:password
    }
    return this.http.post(this.ip+"/api/User/register",payload,{responseType:"text"});
  }
  getkategorije():Observable<Category[]>{
    return this.http.get<Category[]>(this.ip+"/api/Category");
  }
  getOglasi():Observable<Oglas[]>{
    return this.http.get<Oglas[]>(this.ip+"/api/Ads");
  }
  searchOglasi(query:string, location:string, minPrice:number|null, maxPrice:number|null, page:number):Observable<PagedResult<Oglas>>{
    let params:any = { page, pageSize: 10 };
    if (query) params['query'] = query;
    if (location) params['location'] = location;
    if (minPrice != null) params['minPrice'] = minPrice;
    if (maxPrice != null) params['maxPrice'] = maxPrice;
    return this.http.get<PagedResult<Oglas>>(this.ip+"/api/Ads/search", { params });
  }
}
