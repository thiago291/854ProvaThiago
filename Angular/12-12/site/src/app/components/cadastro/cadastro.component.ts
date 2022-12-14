import { CadastroData } from './../../models/cadastro-data.model';
import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent {
  @Output() public sendForm: EventEmitter<CadastroData> = new EventEmitter<CadastroData>();
  public cadastroData: CadastroData = {
    name: "Teste Testington",
    cpf: "000.000.000-00",
    birthdate: "01/01/1950",
    zipCode: "00000-000",
    street: "Rua Teste",
    number: 1,
    complement: "Casa 1",
    district: "Testelândia",
    state: "Testestão",
    city: "Testália",
    email: "teste@teste.com",
    phone: "(00)00000-0000",
    username: "usuarioteste",
    password: "pwdteste"
  }

  constructor(){}
  ngOnInit(){
  }
  public submitForm():void{
    //console.log(this.cadastroData);
    this.sendForm.emit(this.cadastroData);
  }

  public showInputData(event: any): void{
    console.log(event.target.value)
  }
}
