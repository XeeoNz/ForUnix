import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Auto } from '../shared/model';

@Component({
  selector: 'app-auto-create',
  templateUrl: './auto-create.component.html',
  styleUrls: ['./auto-create.component.css']
})
export class AutoCreateComponent implements OnInit {
  autoData: Auto = new Auto();
  errorMessage: string;

  constructor(private router: Router, private http: HttpClient) { }

  ngOnInit(): void {
  }

  submit(){
    this.http.post<Auto>(`https://localhost:44357/api/Autok/`, this.autoData).subscribe(
      () => this.vissza(),
      () => this.errorMessage = 'A hozzáadás sikertelen volt.'
    );
  }

  vissza(){
    this.router.navigate(['']);
  }

}
