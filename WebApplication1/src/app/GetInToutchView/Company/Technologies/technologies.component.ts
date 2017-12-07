import {AfterViewInit, Component} from '@angular/core';
import {AnimationClass} from '../../../animation.class';

@Component({
  selector: 'app-technologies',
  templateUrl: './technologies.html',
  styleUrls: [
    '../../../../assets/css/main.css',
    '../../../../assets/css/services.css'
  ]
})
export class TechnologiesComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    AnimationClass.animWeb();
  }
  constructor() {}
}
