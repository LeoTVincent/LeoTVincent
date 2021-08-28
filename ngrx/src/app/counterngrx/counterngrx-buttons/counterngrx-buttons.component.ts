import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { decrement, increment, reset } from '../state/counterngrx.actions';

@Component({
  selector: 'app-counterngrx-buttons',
  templateUrl: './counterngrx-buttons.component.html',
  styleUrls: ['./counterngrx-buttons.component.css']
})
export class CounterngrxButtonsComponent implements OnInit {

  constructor(private store: Store<{counterngrxProp:{ counter : number}}>) { }

  ngOnInit(): void {
  }
  onIncrement(){
    this.store.dispatch(increment())//dispatch the action
  }
  onDecrement(){
    this.store.dispatch(decrement()) //dispatch the action for decrement
  }
  onReset(){
    this.store.dispatch(reset())
  }
}
