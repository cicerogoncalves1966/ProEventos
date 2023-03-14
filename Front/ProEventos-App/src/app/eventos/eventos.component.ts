import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventsFiltered: any = [];
  widthImg: number = 100;
  marginImg: number = 2;
  imageView = false;
  private _filterList: string = '';


  public get filterList() {
    return this._filterList;
  }

  public set filterList(value: string){
    this._filterList = value;
    this.eventsFiltered = this._filterList ? this.searchEventos(this._filterList): this.eventos;
  }

  searchEventos(filterPer: string): any {
    filterPer = filterPer.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filterPer) != -1 ||
                       evento.local.toLocaleLowerCase().indexOf(filterPer) != -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  viewImage() {
    this.imageView = !this.imageView;
  }

  public getEventos(): void {
    this.eventos = this.http.get('https://localhost:5001/api/eventos').subscribe(
        response => {
          this.eventos = response;
          this.eventsFiltered = response;
        },
        error => console.log(error)
    );
  }
}
