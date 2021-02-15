import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Auto } from '../shared/model';

@Component({
  selector: 'app-auto-details',
  templateUrl: './auto-details.component.html',
  styleUrls: ['./auto-details.component.css']
})
export class AutoDetailsComponent implements OnInit {
  auto: Auto = new Auto();
  errorMessage: string;

  constructor(private router: Router, private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    let id = this.route.snapshot.params['id'];
    this.http.get<Auto>('https://localhost:44357/api/Autok/' + id).subscribe(
      resp => this.auto = resp,
      () => this.errorMessage = 'Hiba az api-val való kommunikáció során.'
    )
  }

  vissza(){
    this.router.navigate(['']);
  }

}
