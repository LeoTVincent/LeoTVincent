import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-counterngrx-output',
  templateUrl: './counterngrx-output.component.html',
  styleUrls: ['./counterngrx-output.component.css']
})
export class CounterngrxOutputComponent implements OnInit {
  counter:number=0;
  constructor(private store: Store<{counterngrxProp:{counter:number}}>) { }

  ngOnInit(): void {
    this.store.select('counterngrxProp')
    .subscribe(data =>{
      this.counter=data.counter;
    })
  }

}
