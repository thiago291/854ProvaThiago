import { EnderecoData } from '../../models/endereco-data.model';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-endereco',
  templateUrl: './endereco.component.html',
  styleUrls: ['./endereco.component.css']
})
export class EnderecoComponent implements OnInit {
  public addressData: EnderecoData = {
    street: "Rua João Silva",
    number: 245,
    complement: "Casa 3, Fundos",
    state: "RJ",
    city: "Macaé",
    district: "Cidade Nova",
    zipCode: "12345-292"
  }

  constructor() {}

  ngOnInit(){
  }
}
