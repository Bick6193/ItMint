import {AfterViewInit, Component} from '@angular/core';
import {AnimationClass} from '../../animation.class';

@Component({
  selector: 'app-technologies',
  templateUrl: './technologies.html'
})
export class TechnologiesComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    AnimationClass.animWeb();
  }
  constructor() {}
}
