import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Auto } from '../shared/model';

@Component({
  selector: 'app-auto-edit',
  templateUrl: './auto-edit.component.html',
  styleUrls: ['./auto-edit.component.css']
})
export class AutoEditComponent implements OnInit {
  autoData: Auto = new Auto();
  errorMessage: string;

  constructor(private router: Router, private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.http.get<Auto>('https://localhost:44357/api/Autok/' + params['id'])
      .subscribe(
        resp => this.autoData = resp,
        () => this.errorMessage = 'Hiba az api-val való kommunikáció során.'
        );
    });
  }

  submit(){
    this.http.put<Auto>('https://localhost:44357/api/Autok/' + this.autoData.modellId, this.autoData).subscribe(
      () => this.vissza(),
      () => this.errorMessage = 'A mentés sikertelen volt.'
    );
  }

  vissza(){
    this.router.navigate(['']);
  }

}
