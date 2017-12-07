import { NgModule } from '@angular/core';
import {MiddleComponent} from './middle.component';
import {routing} from './middle.routing';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

@NgModule({
  imports: [routing, CommonModule, FormsModule],
  declarations: [MiddleComponent]
})
export class LazyMiddleModule {}
