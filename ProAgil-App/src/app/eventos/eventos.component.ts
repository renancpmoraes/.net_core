import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})


export class EventosComponent implements OnInit {

  title = 'ProAgil-App versão 2019';
  eventos: any;

  constructor(private http: HttpClient) {

   }

  ngOnInit() {
    this.getEventos();
  }

  getEventos() {
    this.http.get('https://localhost:5001/WeatherForecast').subscribe(
       response => { this.eventos = response; },
    error => {
      console.log('deu erro');
    });
  }

}
