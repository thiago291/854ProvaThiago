import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AboutComponent } from './components/about/about.component';
import { AddressComponent } from './components/address/address.component';
import { CarouselComponent } from './components/carousel/carousel.component';
import { ContactComponent } from './components/contact/contact.component';
import { FeaturesComponent } from './components/features/features.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { CadastroComponent } from './components/cadastro/cadastro.component';

@NgModule({
  declarations: [
    AppComponent,
    AboutComponent,
    AddressComponent,
    CarouselComponent,
    ContactComponent,
    FeaturesComponent,
    FooterComponent,
    HeaderComponent,
    CadastroComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
