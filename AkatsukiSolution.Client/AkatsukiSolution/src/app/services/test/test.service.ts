import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TestService {
  constructor(private http: HttpClient) {}

  url: string = environment.testUrl;

  testEndpoint(): Observable<string> {
    return this.http.get<string>(this.url + 'ping');
  }
}
