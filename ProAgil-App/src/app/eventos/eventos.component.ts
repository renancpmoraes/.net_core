import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})


export class EventosComponent implements OnInit {

  _filtroLista : string;

  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEvento(this.filtroLista) : this.eventos;
  }

  eventosFiltrados: any = [];
  eventos: any = [];
  imagemLargura = 50;
  imagemMargin = 2;
  mostrarImagem = false;

  constructor(private http: HttpClient) {

   }

  ngOnInit() {
    this.getEventos();
  }

  getEventos() {
    this.http.get('https://localhost:5001/WeatherForecast').subscribe(
       response => {
       this.eventos = response;
       console.log(response); },
    error => {
      console.log('deu erro');
    });
  }

  alternarImagem() {
      this.mostrarImagem = !this.mostrarImagem;
  }

  filtrarEvento(filtroLista: string): any {

    filtroLista = filtroLista.toLocaleLowerCase();
    return this.eventos.filter( evento => evento.tema.toLocaleLowerCase().indexOf(filtroLista) !== -1);
  }

}
