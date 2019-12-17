import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EventoService } from '../_services/evento.service';
import { Evento } from '../_models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})


export class EventosComponent implements OnInit {

  filtroListaStr: string;

  get filtroLista(): string {
    return this.filtroListaStr;
  }
  set filtroLista(value: string) {
    this.filtroListaStr = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEvento() : this.eventos;
  }

  eventosFiltrados: Evento[];
  eventos: Evento[];
  imagemLargura = 50;
  imagemMargin = 2;
  mostrarImagem = false;

  constructor(private eventoService: EventoService) {

   }

  ngOnInit() {
    this.getEventos();
  }

  getEventos() {
<<<<<<< HEAD
    this.eventoService.getAllEvento().subscribe(
    // tslint:disable-next-line: variable-name
    (_eventos: Evento[]) => {
       this.eventos = _eventos;
       this.eventosFiltrados = this.eventos;
       console.log(_eventos); },
=======
    this.http.get('http://localhost:5000/api/evento').subscribe(
       response => {
       this.eventos = response;
       console.log(response); },
>>>>>>> 632e3441ccc19ae84d302f92ee16af5dbfce4585
    error => {
      console.log('deu erro');
    });
  }

  alternarImagem() {
      this.mostrarImagem = !this.mostrarImagem;
  }

  filtrarEvento(): Evento[] {

    this.filtroListaStr = this.filtroListaStr.toLocaleLowerCase();
    return this.eventos.filter(evento => evento.tema.toLocaleLowerCase().indexOf(this.filtroListaStr) !== -1);
  }

}
