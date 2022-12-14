import { Component, OnInit } from '@angular/core';
import { ContactFormData } from 'src/app/models/contact-form-data.model';

@Component({
  selector: 'app-contato',
  templateUrl: './contato.component.html',
  styleUrls: ['./contato.component.css']
})
export class ContatoComponent {
  public btnDisabled = true;
  public formData: ContactFormData = {
    date: "01/01/1950",
    cpf: "000.000.000-00",
    email: "teste@teste.com",
    message: "Olá mundo."
  }
  constructor(){}
  ngOnInit(){
    setTimeout(() => {
      this.btnDisabled = false;
    }, 5000);

  }

  public submitForm():void{
    console.log(this.formData)
  }

  public showInputData(event: any): void{
    console.log(event.target.value)

  }


}
