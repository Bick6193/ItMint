import {AfterViewInit, Component} from '@angular/core';
import {AnimationClass} from '../../animation.class';

@Component({
  selector: 'app-design',
  templateUrl: './design.html'
})
export class DesignComponent implements AfterViewInit {
  ngAfterViewInit(): void {
  AnimationClass.animWeb();
  }
  constructor() {}
}
