import {AfterViewInit, Component} from '@angular/core';
import {AnimationClass} from '../../animation.class';

@Component({
  selector: 'app-industries',
  templateUrl: './industries.html'
})
export class IndustriesComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    AnimationClass.animWeb();
  }
  constructor() {}
}
