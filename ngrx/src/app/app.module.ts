import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CounterComponent } from './counter/counter/counter.component';
import { CounterOutputComponent } from './counter/counter-output/counter-output.component';
import { CounterButtonsComponent } from './counter/counter-buttons/counter-buttons.component';
import { CounterngrxComponent } from './counterngrx/counterngrx/counterngrx.component';
import { CounterngrxOutputComponent } from './counterngrx/counterngrx-output/counterngrx-output.component';
import { CounterngrxButtonsComponent } from './counterngrx/counterngrx-buttons/counterngrx-buttons.component';
import { StoreModule } from '@ngrx/store';
import { counterReducer } from './counterngrx/state/counterngrx.reducer';

@NgModule({
  declarations: [
    AppComponent,
    CounterComponent,
    CounterOutputComponent,
    CounterButtonsComponent,
    CounterngrxComponent,
    CounterngrxOutputComponent,
    CounterngrxButtonsComponent
  ],
  imports: [
    BrowserModule,
    StoreModule.forRoot({counterngrxProp:counterReducer})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
