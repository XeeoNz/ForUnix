import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Auto } from '../shared/model';

@Component({
  selector: 'app-autok',
  templateUrl: './autok.component.html',
  styleUrls: ['./autok.component.css']
})
export class AutokComponent implements OnInit {
  autokList: Auto[];
  dataSource = new MatTableDataSource<Auto>()
  errorMessage: string;
  @ViewChild(MatSort) sort: MatSort;
  displayedColumns: string[] = ['gyartoNev', 'modellNev', 'ajtok', 'teljesitmeny', 'evjarat', 'gombok'];


  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get<Auto[]>('https://localhost:44357/api/Autok').subscribe(
      resp => {
        this.autokList = resp; this.dataSource = new MatTableDataSource<Auto>(this.autokList); 
        this.dataSource.sort = this.sort; },
      () => this.errorMessage = 'Hiba az api-val való kommunikáció során.'
    );
  }

  deleteModellAndReszletek(id: number){
    this.http.delete(`https://localhost:44357/api/Autok/${id}`).subscribe(
      resp => this.ngOnInit(),
      () => this.errorMessage = 'A törlés sikertelen volt.'
    );
  }

}
